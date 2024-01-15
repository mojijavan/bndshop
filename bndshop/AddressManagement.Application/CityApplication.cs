
using System.Collections.Generic;
using AddressManagement.Application.Contracts.City;
using AddressManagement.Domain.CityAgg;

namespace AddressManagement.Application
{
    public class CityApplication:ICityApplication
    {
        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<CityViewModel> Search(CitySearchModel searchModel)
        {
            return _cityRepository.Search(searchModel);
        }

        public List<CityViewModel> GetCitiesWithProvince(long id)
        {
            return _cityRepository.GetCitiesWithProvince(id);

        }

        public List<CityViewModel> GetList()
        {
            return _cityRepository.GetList();
        }
    }
}
