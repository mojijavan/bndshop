using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_BndShopQuery.Contracts.Address;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Application.Contracts.City;
using AddressManagement.Application.Contracts.Province;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Customer.Pages.Address
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditAddress Command { get; set; }
        private readonly IAddressQuery _addressQuery;
        
        private readonly IProvinceApplication _provinceApplication;
        private readonly ICityApplication _cityApplication;
        public SelectList Provinces;
        public SelectList Cities;
        public EditModel(IAddressQuery addressQuery, IProvinceApplication provinceApplication, ICityApplication cityApplication)
        {
            _addressQuery = addressQuery;
            _provinceApplication = provinceApplication;
            _cityApplication = cityApplication;
        }

        public void OnGet(long id)
        {
            Provinces = new SelectList(_provinceApplication.GetList(), "Id", "Pname");
            Cities = new SelectList(_cityApplication.GetCitiesWithProvince(1), "Id", "Pname");
            Command = _addressQuery.GetAddress(id);
        }
        public IActionResult OnPost()
        {
            var result = _addressQuery.Edit(Command);
            return RedirectToPage("./Index");

        }
    }
}
