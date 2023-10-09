
using System.Collections.Generic;
using _01_BndShopQuery.Contracts.ArticleCategory;
using _01_BndShopQuery.Contracts.ProductCategory;

namespace _01_BndShopQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
