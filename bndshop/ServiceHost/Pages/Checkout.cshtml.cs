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
            if (addressMethod == 0)
                return RedirectToPage("./Checkout");
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);
            cart.AddresstId = addressMethod;
            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = _orderApplication.PlaceOrder(cart);
            if (paymentMethod == 1)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                    cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
                    "خرید از درگاه بندرپلاس", orderId);

                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }
            if (paymentMethod == 4)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                    cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
                    "خرید از درگاه بندرپلاس", orderId);

                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
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
        string TOKEN = string.Empty;
        // GET: Ipg
        //[HttpPost]
        //public ActionResult Index(phase1 Phase1)
        //{
        //    generateTokenWithNoSignRequest tokenWithNoSignRequest = new generateTokenWithNoSignRequest()
        //    {
        //        //wSContext.UserId = "41979242",
        //        // wSContext.Password = "698583",
        //        Amount = Phase1.Amount,
        //        //MerchantId = Phase1.MerchantId,
        //        //411398675
        //        RedirectUrl = Phase1.RedirectUrl,
        //        ReserveNum = Phase1.ReserveNum,
        //        TransType = Type.EN_GOODS.ToString()//"EN_GOODS"
        //    };
        //    tokenWithNoSignRequest.WSContext.UserId = "41726609";
        //    tokenWithNoSignRequest.WSContext.Password = "073571";
        //    tokenWithNoSignRequest.MerchantId = 411398675.ToString();


        //    var request = (HttpWebRequest)WebRequest.Create("https://ref.sayancard.ir/ref-payment/RestServices/mts/generateTokenWithNoSign/");

        //    //var postData = "{\"UserName\":41979242,\"Password\":698583}";

        //    var postData = JsonConvert.SerializeObject(tokenWithNoSignRequest);


        //    var data = Encoding.ASCII.GetBytes(postData);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.ContentLength = data.Length;
        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    var response = (HttpWebResponse)request.GetResponse();
        //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    JObject json = JObject.Parse(responseString);
        //    //WSContext a = new WSContext();
        //    // a.
        //    if (json.ContainsKey("Result")) if (json.GetValue("Result").ToString() == "erSucceed")
        //        {
        //            if (json.ContainsKey("Token")) TOKEN = json.GetValue("Token").ToString();
        //            //if (json.ContainsKey("SessionId")) TOKEN = json.GetValue("SessionId").ToString();
        //        }


        //    //ViewBag.token = TOKEN;
        //    //ViewBag.lang = "fa";

        //    Dictionary<string, object> postIpgData = new Dictionary<string, object>();
        //    postIpgData.Add("token", TOKEN);
        //    postIpgData.Add("language", "fa");

        //    //return this.RedirectAndPost("https://say.shaparak.ir/_ipgw_/MainTemplate/payment/", postIpgData);


        //    // return View("test");
        //}
        enum Type
        {
            EN_GOODS,
            EN_BILL_PAY,
            EN_VOCHER,
            EN_TOP_UP,
            EN_THP_PAY
        }

        private class wSContext
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }

        private class generateTokenWithNoSignRequest
        {
            public wSContext WSContext = new wSContext();
            public string TransType { get; set; }
            public string ReserveNum { get; set; }
            public string MerchantId { get; set; }
            public string Amount { get; set; }
            public string RedirectUrl { get; set; }

        }
    }
}