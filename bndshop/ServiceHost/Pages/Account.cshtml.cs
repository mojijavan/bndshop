using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }
        public RegisterAccount RegisterAccount { get; set; }
        public Login Login { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            RegisterAccount = new RegisterAccount();
            Login = new Login();
        }

        public IActionResult OnPostLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _accountApplication.Login(login);
                if (result.IsSuccedded)
                {
                    
                    return RedirectToPage("/Index");
                }
                   

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

        public async Task<IActionResult> OnPostRegister(RegisterAccount registerAccount)
        {
            
            if (ModelState.IsValid)
            {
                var result = _accountApplication.Register(registerAccount);
                if (result.IsSuccedded)
                {
                    Login login = new Login();
                    login.Username = registerAccount.Username;
                    login.Password = registerAccount.Password;
                    var result1 = _accountApplication.Login(login);
                    if (result1.IsSuccedded)
                    {
                        return RedirectToPage("/Index");
                    }
                   
                }
                   
                RegisterMessage = result.Message;
                return RedirectToPage("/Account");
            }
            return Page();
            //RegisterMessage = "تمامی موارد ضروری را وارد کنید";
            //return RedirectToPage("/Account");
        }
    }
}
