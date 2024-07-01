using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_BndShopQuery.Contracts;
using _01_BndShopQuery.Contracts.Address;
using _01_BndShopQuery.Contracts.Product;
using AddressManagement.Application.Contracts.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    //[Authorize]
    public class CheckoutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";
        private readonly IAuthHelper _authHelper;
        
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IOrderApplication _orderApplication;
        private readonly ICartCalculatorService _cartCalculatorService;
        public SelectList Address;
        public List<AddressViewModel> Addresses;
        private readonly IAddressQuery _addressQuery;
        public List<CartItem> cartItems;
        public CheckoutModel(ICartCalculatorService cartCalculatorService, ICartService cartService,
            IProductQuery productQuery, IOrderApplication orderApplication, 
            IZarinPalFactory zarinPalFactory,
            IAuthHelper authHelper, IAddressQuery addressQuery)
        {
            Cart = new Cart();
            
            _cartCalculatorService = cartCalculatorService;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
            _zarinPalFactory = zarinPalFactory;
            _authHelper = authHelper;
            _addressQuery = addressQuery;
        }

        public IActionResult OnGet()
        {
            if (_authHelper.IsAuthenticated())
            {
                
                long accountId = _authHelper.CurrentAccountId();
                var serializer = new JavaScriptSerializer();
                var value = Request.Cookies[CookieName];
                cartItems = serializer.Deserialize<List<CartItem>>(value);
                AddressSearchModel addressSearchModel = new AddressSearchModel();
                addressSearchModel.AccountId = accountId;
                //Address = new SelectList(_addressQuery.GetAddresses(addressSearchModel), "Id", "Description");
                Addresses = _addressQuery.GetAddresses(addressSearchModel);
                if (cartItems != null)
                {
                    foreach (var item in cartItems)
                        item.CalculateTotalItemPrice();
                    Cart = _cartCalculatorService.ComputeCart(cartItems);
                    _cartService.Set(Cart);
                    return Page();
                }
                else return RedirectToPage("./Index");
            }

            else return RedirectToPage("./Account");
            //Address = _addressQuery.GetAddresses(searchModel);
        }

        public IActionResult OnPostPay(int paymentMethod,int addressMethod)
        {
            if (!_authHelper.IsAuthenticated())
                return RedirectToPage("./Account");
            if (paymentMethod == 0)
                return RedirectToPage("./Checkout");
            if (addressMethod == 0&&paymentMethod!=3)
                return RedirectToPage("./Checkout");
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);
            cart.AddresstId = addressMethod;
            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = _orderApplication.PlaceOrder(cart);
            //if (paymentMethod == 1)
            //{
            //    var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
            //        cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
            //        "خرید از درگاه بندرپلاس", orderId);

            //    return Redirect(
            //        $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            //}
            if (paymentMethod == 4)
            {
                string amount = _orderApplication.GetAmountBy(orderId).ToString();
                return RedirectToPage("/Ipg", new { orderID = orderId.ToString(), amount=amount });
                
            }
            var issueTrackingNo = orderId;
            var paymentResult = new PaymentResult();
            paymentResult = paymentResult.Succeeded("سفارش شما با موفقیت ثبت شد. پس از تماس کارشناسان ما و پرداخت وجه، سفارش ارسال خواهد شد", issueTrackingNo.ToString());
            return RedirectToPage("/PaymentResult", paymentResult);
            
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            var orderAmount = _orderApplication.GetAmountBy(oId);
            var verificationResponse =
                _zarinPalFactory.CreateVerificationRequest(authority,
                    orderAmount.ToString(CultureInfo.InvariantCulture));

            var result = new PaymentResult();
            if (status == "OK" && verificationResponse.Status >= 100)
            {
                var issueTrackingNo = _orderApplication.PaymentSucceeded(oId, verificationResponse.RefID);
                Response.Cookies.Delete("cart-items");
                result = result.Succeeded("پرداخت با موفقیت انجام شد.", issueTrackingNo);
                return RedirectToPage("/PaymentResult", result);
            }

            result = result.Failed(
                "پرداخت با موفقیت انجام نشد. درصورت کسر وجه از حساب، مبلغ تا 24 ساعت دیگر به حساب شما بازگردانده خواهد شد.");
            return RedirectToPage("/PaymentResult", result);
        }
       
    
    }
}