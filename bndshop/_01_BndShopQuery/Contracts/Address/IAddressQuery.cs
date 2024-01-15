

using System.Collections.Generic;
using _0_Framework.Application;
using AddressManagement.Application.Contracts.Address;

namespace _01_BndShopQuery.Contracts.Address
{
    public interface IAddressQuery
    {
        List<AddressViewModel> GetAddresses(AddressSearchModel searchModel);
        OperationResult Create(CreateAddress command);
        EditAddress GetAddress(long id);
        OperationResult Edit(EditAddress command);
        OperationResult Delete(AddressViewModel command);
    }
}
