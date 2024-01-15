

namespace _01_BndShopQuery.Contracts.Address
{
    public class AddressQueryViewModel
    {
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public long CityId { get; set; }
    }
}
