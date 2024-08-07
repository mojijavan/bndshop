using System.Collections.Generic;
using AccountManagement.Application.Contracts.Account;
using AddressManagement.Application.Contracts.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceHost.Areas.Administration.Pages.Accounts.Role;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public SelectList Accounts;
        public List<OrderViewModel> Orders;

        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IAddressApplication _addressApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication,IAddressApplication addressApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
            _addressApplication = addressApplication;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
            Orders = _orderApplication.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetItems(id);
            return Partial("Items", items);
        }
        public IActionResult OnGetAddress(long id)
        {
            var items = _addressApplication.GetDetails(id);
            return Partial("Address", items);
        }
    }
}