

using System.Collections.Generic;
using System.Linq;
using AddressManagement.Application.Contracts.Province;
using AddressManagement.Domain.ProvineAgg;

namespace AddressManagement.Infrastructure.EFCore.Repository
{
    public class ProvinceRepository:IProvinceRepository
    {
        private readonly AddressContext _context;

        public ProvinceRepository(AddressContext context)
        {
            _context = context;
        }

        public List<ProvinceViewModel> Search(ProvinceSearchModel searchModel)
        {
            var query = _context.Provinces

                .Select(x => new ProvinceViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Pname = x.Pname,
                    IsNeighbor = x.IsNeighbor,
                    
                });

            if (string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);
            if (string.IsNullOrWhiteSpace(searchModel.Pname))
                query = query.Where(x => x.Pname == searchModel.Pname);
            return query.OrderByDescending(x => x.Id).ToList();
        }

        
        public List<ProvinceViewModel> GetList()
        {
            return  _context.Provinces

                .Select(x => new ProvinceViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Pname = x.Pname,
                    IsNeighbor = x.IsNeighbor,

                }).ToList();

           
        }
    }
}
