
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Threading.Tasks;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProduct Command { get; set; }
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(long id)
        {
                Command = _productApplication.GetDetails(id);
                ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = _productApplication.Edit(Command);
                return RedirectToPage("./Index");
            }
            return Page();
            
        }
    }
}
