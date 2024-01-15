

using System.Collections.Generic;
using _0_Framework.Domain;
using AddressManagement.Application.Contracts.Address;

namespace AddressManagement.Domain.AddressAgg
{
    public interface IAddressRepository : IRepository<long, Address>
    {
        Address GetAddressWith(long id);
        List<AddressViewModel> GetAddressWithAccount(long id);
        EditAddress GetDetails(long id);
        List<AddressViewModel> Search(AddressSearchModel searchModel);
        List<AddressViewModel> GetAddress();
    }
}
