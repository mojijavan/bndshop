

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
        string GetSlugById(long id);
        int GetNewProductCodeById(long id);
        int GetNewProductCategoryCodeById();
        string GetCategoryAndFatherLabel(long id);
    }
}
