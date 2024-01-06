
using System.Collections.Generic;
using _0_Framework.Application;
using AddressManagement.Application.Contracts.Address;

namespace AddressManagement.Application
{
    public class AddressApplication:IAddressApplication
    {
        public OperationResult Create(CreateAddress command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditAddress command)
        {
            throw new System.NotImplementedException();
        }

        public EditAddress GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult IsStock(long id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult NotInStock(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<AddressViewModel> Search(AddressSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }

        public List<AddressViewModel> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public OperationResult UpdateCustomerDiscountRate(long id, int customerDiscountRate)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult UpdateColleagueDiscountRate(long id, int colleagueDiscountRate)
        {
            throw new System.NotImplementedException();
        }
    }
}
