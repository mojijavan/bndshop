

using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace AddressManagement.Infrastructure.EFCore.Repository
{
    public class AddressRepository : RepositoryBase<long, Address>, IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context) : base(context)
        {
            _context = context;
        }
        public Address GetAddressWith(long id)
        {
            return _context.Addresses.Find(id);
        }

        public List<AddressViewModel> GetAddressWithAccount(long id)
        {
            return _context.Addresses
                .Where(x => x.AccountId == id)
                .Include(x=>x.Province)
                .Include(x=>x.City)
                .Select(x => new AddressViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                AccountId = x.AccountId,
                ProvinceName= x.Province.Name,
                CityName = x.City.Name,
                ProvinceId = x.ProvinceId,
                CityId = x.CityId
            }).ToList();
        }

        public EditAddress GetDetails(long id)
        {
            return _context.Addresses.Include(x => x.Province)
                .Include(x => x.City).Select(x => new EditAddress()
            {
                AccountId = x.AccountId,CityId=x.CityId,Description=x.Description,
                ProvinceId = x.ProvinceId,PostalCode = x.PostalCode,Id=x.Id,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AddressViewModel> Search(AddressSearchModel searchModel)
        {
            var query = _context.Addresses
                .Include(x=>x.Province)
                .Include(x=>x.City)
                .Select(x => new AddressViewModel()
                {
                    Id = x.Id,
                    AccountId = x.AccountId,ProvinceId = x.ProvinceId,CityId=x.CityId,Description=x.Description,PostalCode=x.PostalCode,ProvinceName = x.Province.Pname,CityName=x.City.Pname
                    
                });

            if (searchModel.AccountId!=0)
                query = query.Where(x => x.AccountId==searchModel.AccountId);

            if (searchModel.ProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.ProvinceId);

            if (searchModel.CityId != 0)
                query = query.Where(x => x.CityId == searchModel.CityId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<AddressViewModel> GetAddress()
        {
            return _context.Addresses.Include(x => x.Province)
                .Include(x => x.City)
                .Select(x => new AddressViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                ProvinceName = x.Province.Name,
                CityName = x.City.Name,
                AccountId =x.AccountId,ProvinceId=x.ProvinceId,CityId=x.CityId
            }).ToList();
        }
    }
}
