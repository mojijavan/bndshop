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
    public class EditModel : PageModel
    {
        public EditAddress Command;
        private readonly IAddressQuery _addressQuery;

        public EditModel(IAddressQuery addressQuery)
        {
            _addressQuery = addressQuery;
        }

        public void OnGet(long id)
        {
            Command = _addressQuery.GetAddress(id);
        }
        public IActionResult OnPost()
        {
            var result = _addressQuery.Edit(Command);
            return RedirectToPage("./Index");

        }
    }
}
