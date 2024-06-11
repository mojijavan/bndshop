
using _0_Framework.Application;
using FinanaceManagement.Application.Contracts.Cost;
using FinanaceManagement.Application.Contracts.CostCategory;
using System.Collections.Generic;

namespace FinanaceManagement.Application
{
    public class CostCategoryApplication : ICostCategoryApplication
    {
        public OperationResult Create(CreateCostCategory command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Delete(CostCategoryViewModel command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditCostCategory command)
        {
            throw new System.NotImplementedException();
        }

        public List<CostCategoryViewModel> GetCostCategories()
        {
            throw new System.NotImplementedException();
        }

        public EditCostCategory GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<CostCategoryViewModel> Search(CostCategorySearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
