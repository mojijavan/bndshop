

using System.Collections.Generic;
using AddressManagement.Application.Contracts.City;

namespace AddressManagement.Domain.CityAgg
{
    public interface ICityRepository
    {
        List<CityViewModel> Search(CitySearchModel searchModel);
        List<CityViewModel> GetList();
        List<CityViewModel> GetCitiesWithProvince(long id);
    }
}
