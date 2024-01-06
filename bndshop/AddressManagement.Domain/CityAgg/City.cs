

using System.Collections.Generic;
using _0_Framework.Domain;
using AddressManagement.Domain.AddressAgg;
using AddressManagement.Domain.ProvineAgg;

namespace AddressManagement.Domain.CityAgg
{
    public class City: EntityBase
    {
        public string Name { get; private set; }
        public string Pname { get; private set; }
        public long ProvinceId { get; set; }
        public bool IsLocalLocation { get; private set; }
        public Province Province { get; private set; }
        public List<Address> Addresses { get; set; }
        public long DistanceKM { get; private set; }
    }
}
