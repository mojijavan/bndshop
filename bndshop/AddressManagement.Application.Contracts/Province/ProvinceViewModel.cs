

using System.Collections.Generic;
using AddressManagement.Application.Contracts.City;

namespace AddressManagement.Application.Contracts.Province
{
    public class ProvinceViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Pname { get;  set; }
        public bool IsNeighbor { get;  set; }
        public List<CityViewModel> Cities { get;  set; }
    }
}
