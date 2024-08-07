using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Product;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems;
        public const string CookieName = "cart-items";
        private readonly IProductQuery _productQuery;
        private readonly IAuthHelper _authHelper;

        public CartModel(IProductQuery productQuery,IAuthHelper authHelper)
        {
            _authHelper = authHelper;
            CartItems = new List<CartItem>();
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            if (value != null)
            {
                var cartItems = serializer.Deserialize<List<CartItem>>(value);
                foreach (var item in cartItems)
                    item.CalculateTotalItemPrice();

                CartItems = _productQuery.CheckInventoryStatus(cartItems);
            }
            
        }

        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemToRemove);
            var options = new CookieOptions {Expires = DateTime.Now.AddDays(2)};
            options.IsEssential = true;
            Response.Cookies.Append(CookieName, serializer.Serialize(cartItems), options);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnGetGoToCheckOut()
        {
            if (!_authHelper.IsAuthenticated()) return RedirectToPage("/Account");
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
            {
                item.TotalItemPrice = item.UnitPrice * item.Count;
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);

            //if (CartItems.Any(x => !x.IsInStock))
            //    return RedirectToPage("/Cart");
            //return RedirectToPage("/Checkout");

            return RedirectToPage(CartItems.Any(x => !x.IsInStock) ? "/Cart" : "/Checkout");
        }
    }
}