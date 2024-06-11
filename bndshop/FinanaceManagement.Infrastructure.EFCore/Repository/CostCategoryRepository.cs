

using FinanaceManagement.Application.Contracts.CostCategory;
using FinanaceManagement.Domain.CostCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinanaceManagement.Infrastructure.EFCore.Repository
{
    public class CostCategoryRepository : ICostCategoryRepository
    {
        public void Create(CostCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<CostCategory, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public CostCategory Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<CostCategory> Get()
        {
            throw new NotImplementedException();
        }

        public List<CostCategoryViewModel> GetCostCategories()
        {
            throw new NotImplementedException();
        }

        public CostCategoryViewModel GetCostModelWith(long id)
        {
            throw new NotImplementedException();
        }

        public EditCostCategory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<CostCategoryViewModel> Search(CostCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
