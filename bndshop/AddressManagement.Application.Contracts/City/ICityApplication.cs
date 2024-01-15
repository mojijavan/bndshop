

using System.Collections.Generic;

namespace AddressManagement.Application.Contracts.City
{
    public interface ICityApplication
    {
        List<CityViewModel> Search(CitySearchModel searchModel);
        List<CityViewModel> GetCitiesWithProvince(long id);
        List<CityViewModel> GetList();
    }
}
