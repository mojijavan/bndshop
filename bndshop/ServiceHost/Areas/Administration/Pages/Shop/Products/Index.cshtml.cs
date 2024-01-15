
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public List<ProductViewModel> Product;
        public ProductSearchModel SearchModel;
        public SelectList ProductCategories;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories =
                new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Product = _productApplication.Search(searchModel);
        }
        public void OnPost(ProductSearchModel searchModel)
        {
            ProductCategories =
                new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Product = _productApplication.Search(searchModel);
        }
        //public IActionResult OnGetCreate()
        //{
        //    var command = new CreateProduct();
        //    command.Categories = _productCategoryApplication.GetProductCategories();
        //    return Partial("./Create", command);
        //}

        //public JsonResult OnPostCreate(CreateProduct command)
        //{
        //    var result = _productApplication.Create(command);
        //    return new JsonResult(result);
        //}

        //public IActionResult OnGetEdit(long id)
        //{
        //    var product = _productApplication.GetDetails(id);
        //    product.Categories = _productCategoryApplication.GetProductCategories();
        //    return Partial("./Edit", product);
        //}

        public IActionResult OnGetIsInStock(int id)
        {
            _productApplication.IsStock(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetNotInStock(int id)
        {
            _productApplication.NotInStock(id);
            return RedirectToPage("./Index");
        }
        //public JsonResult OnPostEdit(EditProduct command)
        //{
        //    var result=_productApplication.Edit(command);
        //    return new JsonResult(result);
        //}
        public IActionResult OnGetRemove(long id)
        {
            var result = _productApplication.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _productApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
