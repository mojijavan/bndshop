
using System.Collections.Generic;
using _0_Framework.Application;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Domain.AddressAgg;

namespace AddressManagement.Application
{
    public class AddressApplication:IAddressApplication
    {
        private readonly IAddressRepository _addressRepository;

        public AddressApplication(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public OperationResult Create(CreateAddress command)
        {
            var operation = new OperationResult();
            var address = new Address(command.AccountId,command.Description,command.PostalCode,command.ProvinceId,command.CityId);
            _addressRepository.Create(address);
            _addressRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAddress command)
        {
            var operation = new OperationResult();
            var address = _addressRepository.Get(command.Id);
            if (address == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            address.Edit(command.AccountId, command.Description, command.PostalCode, command.ProvinceId, command.CityId);
            _addressRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAddress GetDetails(long id)
        {
           return  _addressRepository.GetDetails(id);
        }

        public List<AddressViewModel> Search(AddressSearchModel searchModel)
        {
            return _addressRepository.Search(searchModel);
        }

        public List<AddressViewModel> GetAddresses()
        {
            return _addressRepository.GetAddress();
        }

        public OperationResult Delete(AddressViewModel command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            if (!_addressRepository.Exists(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
            _addressRepository.Delete(command.Id);
            _addressRepository.SaveChanges();
            return operation;
        }
    }
}
