

using _0_Framework.Application;
using System.Collections.Generic;

namespace FinanaceManagement.Application.Contracts.Cost
{
   public interface ICostApplication
    {
        OperationResult Create(CreateCost command);
        OperationResult Edit(EditCost command);
        EditCost GetDetails(long id);

        List<CostViewModel> Search(CostSearchModel searchModel);
        List<CostViewModel> GetCosts();

        public OperationResult Delete(CostViewModel command);
    }
}
