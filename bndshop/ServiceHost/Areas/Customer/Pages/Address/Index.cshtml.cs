using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(IAddressQuery addressQuery)
        {
            _addressQuery = addressQuery;
        }

        public void OnGet(AddressSearchModel searchModel)
        {
            Address = _addressQuery.GetAddresses(searchModel);
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
