

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
        //private readonly IShopAddressAcl _shopAddressAcl;
        private readonly IAddressApplication _addressApplication;


        public AddressQuery(IAddressApplication addressApplication)
        {
            
            _addressApplication = addressApplication;
        }

        public List<AddressViewModel> GetAddresses(AddressSearchModel searchModel)
        {
            return _addressApplication.Search(searchModel); // _shopAddressAcl.GetAddressesAcl(searchModel);
        }

        public OperationResult Create(CreateAddress command)
        {
            return _addressApplication.Create(command);// _shopAddressAcl.CreateAcl(command);
        }

        public EditAddress GetAddress(long id)
        {
            return _addressApplication.GetDetails(id);// _shopAddressAcl.GetAddressAcl(id);
        }

        public OperationResult Edit(EditAddress command)
        {
            return _addressApplication.Edit(command);// _shopAddressAcl.EditAcl(command);
        }

        public OperationResult Delete(AddressViewModel command)
        {
            return _addressApplication.Delete(command); //_shopAddressAcl.DeleteAcl(command);
        }
    }
}
