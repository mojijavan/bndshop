

using _0_Framework.Domain;
using FinanaceManagement.Application.Contracts.CostCategory;
using System.Collections.Generic;

namespace FinanaceManagement.Domain.CostCategoryAgg
{
   public interface ICostCategoryRepository : IRepository<long, CostCategory>
    {
        EditCostCategory GetDetails(long id);
        List<CostCategoryViewModel> Search(CostCategorySearchModel searchModel);
        List<CostCategoryViewModel> GetCostCategories();
        CostCategoryViewModel GetCostModelWith(long id);
    }
}
