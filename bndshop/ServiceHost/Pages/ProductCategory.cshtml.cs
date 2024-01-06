using System.Collections.Generic;
using _0_Framework.Application;
using _01_BndShopQuery.Contracts.ProductCategory;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        public List<ProductCategoryQueryModel> ProductCategoryList;
        public List<ProductCategoryTopRefrence> ProductCategoryTopRefrence;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string parentSlug, string slug, string label)
        {
            ProductCategoryTopRefrence = _productCategoryQuery.GetTopList(parentSlug, slug, label);
            if (slug == null && label == null)
            {
                ProductCategoryList = _productCategoryQuery.GetProductCategoryWithParent(parentSlug);
                ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(parentSlug, label);
            }
            if(slug!=null)
                ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(slug, label);

        }
    }
}
