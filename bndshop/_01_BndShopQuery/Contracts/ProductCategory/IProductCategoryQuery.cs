using System.Collections.Generic;

namespace _01_BndShopQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug,string label);
        //List<ProductCategoryQueryModel> GetProductCategoryChildWith(string slug);
        long GetIdWith(string slug);
        List<ProductCategoryTopRefrence> GetTopList(string parentSlug, string slug, string label);
       
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
        List<ProductCategoryQueryModel> GetProductCategoryWithParent(string slug);
    }
}
