using _01_BndShopQuery.Contracts.ArticleCategory;
using _01_BndShopQuery.Contracts.ProductCategory;
using System.Collections.Generic;

namespace _01_BndShopQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
