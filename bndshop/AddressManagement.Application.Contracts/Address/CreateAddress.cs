

using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AddressManagement.Application.Contracts.Address
{
    public class CreateAddress
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long AccountId { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get;  set; }

        [RegularExpression(@"^\d{10}$",ErrorMessage =ValidationMessages.InvalidFileFormat)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PostalCode { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long ProvinceId { get;  set; }
        public bool IsRemoved { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long CityId { get;  set; }
    }
}
