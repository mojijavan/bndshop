﻿using System.Collections.Generic;

namespace _01_BndShopQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        //ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategories();
        //List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}
