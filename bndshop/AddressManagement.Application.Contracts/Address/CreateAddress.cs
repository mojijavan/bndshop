

namespace AddressManagement.Application.Contracts.Address
{
    public class CreateAddress
    {
        public long AccountId { get;  set; }
        public string Description { get;  set; }
        public string PostalCode { get;  set; }
        public long ProvinceId { get;  set; }
        public long CityId { get;  set; }
    }
}
