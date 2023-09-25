﻿
using System.Collections.Generic;

using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductPicture
{
   public  interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
