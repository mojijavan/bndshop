
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Threading.Tasks;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateProduct Command { get; set; }
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            Command = new CreateProduct();
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }

        public async Task<IActionResult> OnPost(CreateProduct command)
        {
            if (ModelState.IsValid)
            {
                var result = _productApplication.Create(command);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
