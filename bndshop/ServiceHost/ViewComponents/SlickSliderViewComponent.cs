using _01_BndShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlickSliderViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;
        public string Title;
        public SlickSliderViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke(string id)
        {

            var products = _productQuery.SlickSlider(id);
            return View(products);
        }
    }
}
