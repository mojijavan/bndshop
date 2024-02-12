using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Address;
using AddressManagement.Application.Contracts.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Customer.Pages.Address
{
    public class IndexModel : PageModel
    {
        public List<AddressViewModel> Address;
        private readonly IAddressQuery _addressQuery;
        private readonly IAuthHelper _authHelper;

        public IndexModel(IAddressQuery addressQuery, IAuthHelper authHelper)
        {
            _addressQuery = addressQuery;
            _authHelper = authHelper;
        }

        public void OnGet(AddressSearchModel searchModel)
        {
            if (_authHelper.IsAuthenticated())
            {
                searchModel.AccountId = _authHelper.CurrentAccountId();
                Address = _addressQuery.GetAddresses(searchModel);
            }
           
        }
        public IActionResult OnGetRemove(long id)
        {
            //_colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            //_colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
