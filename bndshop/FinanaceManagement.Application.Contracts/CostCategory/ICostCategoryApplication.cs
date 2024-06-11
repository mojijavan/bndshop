

using _0_Framework.Application;
using FinanaceManagement.Application.Contracts.Cost;
using System.Collections.Generic;

namespace FinanaceManagement.Application.Contracts.CostCategory
{
   public interface ICostCategoryApplication
    {
        OperationResult Create(CreateCostCategory command);
        OperationResult Edit(EditCostCategory command);
        List<CostCategoryViewModel> Search(CostCategorySearchModel searchModel);
        EditCostCategory GetDetails(long id);
        List<CostCategoryViewModel> GetCostCategories();
        public OperationResult Delete(CostCategoryViewModel command);
    }
}
