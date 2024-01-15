

using System.Collections.Generic;
using AddressManagement.Application.Contracts.Province;
using AddressManagement.Domain.ProvineAgg;

namespace AddressManagement.Application
{
    public class ProvinceApplication:IProvinceApplication
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceApplication(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public List<ProvinceViewModel> Search(ProvinceSearchModel searchModel)
        {
            return _provinceRepository.Search(searchModel);
        }

        public List<ProvinceViewModel> GetList()
        {
            return _provinceRepository.GetList();
        }
    }
}
