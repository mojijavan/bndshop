

using _0_Framework.Application;
using FinanaceManagement.Application.Contracts.Cost;
using System.Collections.Generic;

namespace FinanaceManagement.Application
{
    public class CostApplication : ICostApplication
    {
        public OperationResult Create(CreateCost command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Delete(CostViewModel command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditCost command)
        {
            throw new System.NotImplementedException();
        }

        public List<CostViewModel> GetCosts()
        {
            throw new System.NotImplementedException();
        }

        public EditCost GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<CostViewModel> Search(CostSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
