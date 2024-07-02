using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public class Login
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = ValidationMessages.InvalidMobile)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [RegularExpression(@"^[A-Za-z0-9_-]{6,20}$", ErrorMessage = ValidationMessages.InvalidPassword)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }
    }
}
