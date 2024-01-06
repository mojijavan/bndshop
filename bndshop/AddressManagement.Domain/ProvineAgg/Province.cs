

using System.Collections.Generic;
using _0_Framework.Domain;
using AddressManagement.Domain.AddressAgg;
using AddressManagement.Domain.CityAgg;

namespace AddressManagement.Domain.ProvineAgg
{
    public class Province: EntityBase
    {
        public string Name { get; private set; }
        public string Pname { get; private set; }
        public bool IsNeighbor { get; private set; }
        public List<City> Cities { get; private set; }
        public bool IsLocalProvince { get; private set; }
        public List<Address> Addresses { get; private set; }
    }
}
