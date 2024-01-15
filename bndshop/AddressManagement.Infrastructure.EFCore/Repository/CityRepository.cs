

using System.Collections.Generic;
using System.Linq;
using AddressManagement.Application.Contracts.City;
using AddressManagement.Domain.CityAgg;
using Microsoft.EntityFrameworkCore;

namespace AddressManagement.Infrastructure.EFCore.Repository
{
    public class CityRepository:ICityRepository
    {
        private readonly AddressContext _context;

        public CityRepository(AddressContext context)
        {
            _context = context;
        }

        public List<CityViewModel> Search(CitySearchModel searchModel)
        {
            var query = _context.Cities
                .Include(x=>x.Province)

                .Select(x => new CityViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Pname = x.Pname,
                    Province = x.Province.Name
                });

            if (string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);
            if (string.IsNullOrWhiteSpace(searchModel.Pname))
                query = query.Where(x => x.Pname == searchModel.Pname);
            if (string.IsNullOrWhiteSpace(searchModel.Province))
                query = query.Where(x => x.Province == searchModel.Province);
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<CityViewModel> GetList()
        {
            return  _context.Cities
                .Include(x => x.Province)

                .Select(x => new CityViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Pname = x.Pname,
                    Province = x.Province.Name
                }).ToList();
        }

        public List<CityViewModel> GetCitiesWithProvince(long id)
        {
            return _context.Cities.Where(x => x.ProvinceId == id)
                .Select(x=>new CityViewModel()
                {
                    Id=x.Id,Pname = x.Pname
                }).ToList();
        }
    }
}
