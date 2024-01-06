using System;
using System.Collections.Generic;

using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
   public interface IProductApplication
   {
       OperationResult Create(CreateProduct command);
       OperationResult Edit(EditProduct command);
       EditProduct GetDetails(long id);
       OperationResult IsStock(long id);
       OperationResult NotInStock(long id);
       OperationResult Remove(long id);
       OperationResult Restore(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
       List<ProductViewModel> GetProducts();
       OperationResult UpdatePrice(long id,double unitPrice);
       OperationResult UpdateCount(long id, long count);
       OperationResult UpdateCustomerDiscountRate(long id, int customerDiscountRate);
       OperationResult UpdateColleagueDiscountRate(long id, int colleagueDiscountRate);
       public OperationResult Delete(ProductViewModel command);
   }
}
