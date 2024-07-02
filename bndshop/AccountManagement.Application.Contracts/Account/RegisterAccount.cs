using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Display(Name = "نام کامل")]
        [StringLength(200,ErrorMessage =ValidationMessages.MaxLenght)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = ValidationMessages.InvalidMobile)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]        
        [RegularExpression(@"^[A-Za-z0-9_-]{6,20}$", ErrorMessage = ValidationMessages.InvalidPassword)]
        [Display(Name = "پسورد")]        
        public string Password { get; set; }
        
        
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }

        
        [StringLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = ValidationMessages.InvalidEmailAddress)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        public long RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
