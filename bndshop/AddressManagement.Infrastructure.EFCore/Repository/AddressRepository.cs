

using System.Collections.Generic;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Domain.AddressAgg;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace AddressManagement.Infrastructure.EFCore.Repository
{
    public class AddressRepository:IAddressRepository
    {
        private readonly AddressContext _addressContext;

        public AddressRepository(AddressContext addressContext)
        {
            _addressContext = addressContext;
        }

        public Address GetAddressWith(long id)
        {
            return _addressContext.Addresses.Find(id);
        }

        public List<AddressViewModel> GetAddressWithAccount(long id)
        {
            throw new System.NotImplementedException();
        }

        public EditAddress GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<AddressViewModel> Search(AddressSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }

        public List<AddressViewModel> GetAddress()
        {
            throw new System.NotImplementedException();
        }
    }
}
