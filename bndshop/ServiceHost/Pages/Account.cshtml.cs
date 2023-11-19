using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }


        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {
            if (ModelState.IsValid)
            {
                var result = _accountApplication.Login(command);
                if (result.IsSuccedded)
                    return RedirectToPage("/Index");

                LoginMessage = result.Message;
                return RedirectToPage("/Account");
            }

           
            LoginMessage ="وارد کردن نام کاربری و پسورد ضروری می باشد";
            return RedirectToPage("/Account");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAccount command)
        {
            
            if (ModelState.IsValid)
            {
                var result = _accountApplication.Register(command);
                if (result.IsSuccedded)
                    return RedirectToPage("/Account");
                RegisterMessage = result.Message;
                return RedirectToPage("/Account");
            }

            RegisterMessage = "تمامی موارد ضروری را وارد کنید";
            return RedirectToPage("/Account");
        }
    }
}
