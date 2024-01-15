

using System.Collections.Generic;
using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Address;
using AddressManagement.Application.Contracts.Address;
using ShopManagement.Domain.Services;
using ShopManagement.Infrastructure.AddressAcl;

namespace _01_BndShopQuery.Query
{
    public class AddressQuery: IAddressQuery
    {
        private readonly IShopAddressAcl _shopAddressAcl;

        public AddressQuery(IShopAddressAcl shopAddressAcl)
        {
            _shopAddressAcl = shopAddressAcl;
        }

        public List<AddressViewModel> GetAddresses(AddressSearchModel searchModel)
        {
            return _shopAddressAcl.GetAddressesAcl(searchModel);
        }

        public OperationResult Create(CreateAddress command)
        {
            return _shopAddressAcl.CreateAcl(command);
        }

        public EditAddress GetAddress(long id)
        {
            return _shopAddressAcl.GetAddressAcl(id);
        }

        public OperationResult Edit(EditAddress command)
        {
            return _shopAddressAcl.EditAcl(command);
        }

        public OperationResult Delete(AddressViewModel command)
        {
            return _shopAddressAcl.DeleteAcl(command);
        }
    }
}
