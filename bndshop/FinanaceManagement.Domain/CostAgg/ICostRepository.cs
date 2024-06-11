

using _0_Framework.Domain;
using FinanaceManagement.Application.Contracts.Cost;
using System.Collections.Generic;

namespace FinanaceManagement.Domain.CostAgg
{
   public interface ICostRepository : IRepository<long, Cost>
    {
        Cost GetCostWithCategory(long id);
        EditCost GetDetails(long id);
        List<CostViewModel> Search(CostSearchModel searchModel);
        List<CostViewModel> GetCosts();
    }
}
