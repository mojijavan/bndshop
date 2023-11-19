
using System.Collections;
using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);

        List<ProductCategoryViewModel> GetProductCategories();
        OperationResult UpdateLastProductCode(long id, int lastProductCode);
    }
}
