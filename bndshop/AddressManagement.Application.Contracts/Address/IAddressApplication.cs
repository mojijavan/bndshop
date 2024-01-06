

using System.Collections.Generic;
using _0_Framework.Application;

namespace AddressManagement.Application.Contracts.Address
{
    public interface IAddressApplication
    {
        OperationResult Create(CreateAddress command);
        OperationResult Edit(EditAddress command);
        EditAddress GetDetails(long id);
        OperationResult IsStock(long id);
        OperationResult NotInStock(long id);
        List<AddressViewModel> Search(AddressSearchModel searchModel);
        List<AddressViewModel> GetProducts();

        OperationResult UpdateCustomerDiscountRate(long id, int customerDiscountRate);
        OperationResult UpdateColleagueDiscountRate(long id, int colleagueDiscountRate);
    }
}
