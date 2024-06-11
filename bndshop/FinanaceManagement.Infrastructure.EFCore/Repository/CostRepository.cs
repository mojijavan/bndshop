

using FinanaceManagement.Application.Contracts.Cost;
using FinanaceManagement.Domain.CostAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinanaceManagement.Infrastructure.EFCore.Repository
{
    public class CostRepository : ICostRepository
    {
        public void Create(Cost entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Cost, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Cost Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<Cost> Get()
        {
            throw new NotImplementedException();
        }

        public List<CostViewModel> GetCosts()
        {
            throw new NotImplementedException();
        }

        public Cost GetCostWithCategory(long id)
        {
            throw new NotImplementedException();
        }

        public EditCost GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<CostViewModel> Search(CostSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
