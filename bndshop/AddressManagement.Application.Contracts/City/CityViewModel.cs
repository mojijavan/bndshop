

namespace AddressManagement.Application.Contracts.City
{
    public class CityViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Pname { get;  set; }
        public long ProvinceId { get; set; }
        public bool IsLocalLocation { get;  set; }
        public string Province { get;  set; }
    }
}
