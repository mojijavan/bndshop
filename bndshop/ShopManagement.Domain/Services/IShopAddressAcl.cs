

using System.Collections.Generic;
using _0_Framework.Application;
using AddressManagement.Application.Contracts.Address;

namespace ShopManagement.Domain.Services
{
    public interface IShopAddressAcl
    {
        EditAddress GetAddressAcl(long id);
        List<AddressViewModel> GetAddressesAcl(AddressSearchModel searchModel);
        OperationResult CreateAcl(CreateAddress command);
        OperationResult EditAcl(EditAddress command);
        OperationResult DeleteAcl(AddressViewModel command);
    }
}
