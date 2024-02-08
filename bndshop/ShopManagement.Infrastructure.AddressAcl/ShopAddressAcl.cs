

using System.Collections.Generic;
using _0_Framework.Application;
using AddressManagement.Application.Contracts.Address;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.AddressAcl
{
    public class ShopAddressAcl:IShopAddressAcl
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAddressApplication _addressApplication;
        

        public ShopAddressAcl(IAuthHelper authHelper, IAddressApplication addressApplication)
        {
            _authHelper = authHelper;
            _addressApplication = addressApplication;
        }

        public EditAddress GetAddressAcl(long id)
        {
            EditAddress editAddress = _addressApplication.GetDetails(id);
            var id1 = _authHelper.CurrentAccountId();
            
            if (editAddress.AccountId == _authHelper.CurrentAccountId())
                return editAddress;
            return new EditAddress();
        }
        public List<AddressViewModel> GetAddressesAcl(AddressSearchModel searchModel)
        {
            searchModel.AccountId = _authHelper.CurrentAccountId();
            if(searchModel.AccountId!=0)
             return _addressApplication.Search(searchModel);
            return new List<AddressViewModel>();
        
        }

        public OperationResult CreateAcl(CreateAddress command)
        {
            command.AccountId= _authHelper.CurrentAccountId();
            return _addressApplication.Create(command);
        }

        public OperationResult EditAcl(EditAddress command)
        {
            command.AccountId = _authHelper.CurrentAccountId();
            return _addressApplication.Edit(command);
        }

        public OperationResult DeleteAcl(AddressViewModel command)
        {
            return _addressApplication.Delete(command);
        }
    }
}
