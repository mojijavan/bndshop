

using System.Collections.Generic;
using AddressManagement.Application.Contracts.Address;

namespace AddressManagement.Domain.AddressAgg
{
    public interface IAddressRepository
    {
        Address GetAddressWith(long id);
        List<AddressViewModel> GetAddressWithAccount(long id);
        EditAddress GetDetails(long id);
        List<AddressViewModel> Search(AddressSearchModel searchModel);
        List<AddressViewModel> GetAddress();
    }
}
