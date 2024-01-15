

namespace AddressManagement.Application.Contracts.Address
{
    public class AddressViewModel
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public long AccountId { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public long ProvinceId { get; set; }
        public bool IsRemoved { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public long CityId { get; set; }
    }
}
