

using System.Collections.Generic;
using AddressManagement.Application.Contracts.Province;

namespace AddressManagement.Domain.ProvineAgg
{
    public interface IProvinceRepository
    {
        List<ProvinceViewModel> Search(ProvinceSearchModel searchModel);
        List<ProvinceViewModel> GetList();
    }
}
