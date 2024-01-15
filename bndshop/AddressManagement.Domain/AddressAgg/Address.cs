

using System;
using _0_Framework.Domain;
using AddressManagement.Domain.CityAgg;
using AddressManagement.Domain.ProvineAgg;

namespace AddressManagement.Domain.AddressAgg
{
    public class Address: EntityBase
    {
        public long AccountId { get; private set; }
        public string Description { get; private set; }
        public string PostalCode { get; private set; }
        public bool IsRemoved { get; private set; }
        public long ProvinceId { get; private set; }
        public long CityId { get; private set; }
        public City City { get; private set; }
        public Province Province { get; private set; }

        public Address(long accountId,string description,string postalCode,long provinceId,long cityId)
        {
            AccountId = accountId;
            Description = description;
            CreationDate=DateTime.Now;
            PostalCode = postalCode;
            CreationDate = DateTime.Now;
            ProvinceId = provinceId;
            CityId = cityId;
        }
        public void Edit(long accountId, string description, string postalCode, long provinceId, long cityId)
        {
            AccountId = accountId;
            Description = description;
            PostalCode = postalCode;
            ProvinceId = provinceId;
            CityId = cityId;
        }
    }
}
