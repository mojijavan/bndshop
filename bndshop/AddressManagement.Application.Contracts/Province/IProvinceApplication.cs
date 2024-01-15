

using System.Collections.Generic;
using AddressManagement.Application.Contracts.City;

namespace AddressManagement.Application.Contracts.Province
{
    public interface IProvinceApplication
    {
        List<ProvinceViewModel> Search(ProvinceSearchModel searchModel);
        List<ProvinceViewModel> GetList();
        
    }
}
