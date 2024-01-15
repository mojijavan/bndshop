
using _01_BndShopQuery.Contracts.Address;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Application.Contracts.City;
using AddressManagement.Application.Contracts.Province;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Customer.Pages.Address
{
    public class CreateModel : PageModel
    {
        public CreateAddress Command;
        private readonly IAddressQuery _addressQuery;
        private readonly IProvinceApplication _provinceApplication;
        private readonly ICityApplication _cityApplication;
        public SelectList Provinces;
        public SelectList Cities;
        public CreateModel(IAddressQuery addressQuery, IProvinceApplication provinceApplication, ICityApplication cityApplication)
        {
          
            _addressQuery = addressQuery;
            _provinceApplication = provinceApplication;
            _cityApplication = cityApplication;
        }

        public void OnGet()
        {
            Provinces = new SelectList(_provinceApplication.GetList(), "Id", "Pname");
            Cities = new SelectList(_cityApplication.GetCitiesWithProvince(1), "Id", "Pname");
            Command = new CreateAddress();
        }
        public IActionResult OnPost(CreateAddress command)
        {
            var result = _addressQuery.Create(command);
            return RedirectToPage("./Index");
        }
        public JsonResult OnGetCities(long id)
        {
            var result = _cityApplication.GetCitiesWithProvince(id);
            return new JsonResult(result);
        }
    }
}
