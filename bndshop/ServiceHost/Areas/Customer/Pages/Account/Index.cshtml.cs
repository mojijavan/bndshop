using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Customer.Pages.Account
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        

        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;
        public AccountViewModel Command;
        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication,IAuthHelper authHelper)
        {
            _authHelper = authHelper;
            _roleApplication = roleApplication;
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            if (_authHelper.IsAuthenticated())
            {
                Command = _accountApplication.GetAccountBy(_authHelper.CurrentAccountId());
            }
        }
        //public IActionResult OnGetEdit(long id)
        //{
        //    var account = _accountApplication.GetDetails(id);
        //    account.Roles = _roleApplication.List();
        //    return Partial("Edit", account);
        //}

        //public JsonResult OnPostEdit(EditAccount command)
        //{
        //    var result = _accountApplication.Edit(command);
        //    return new JsonResult(result);
        //}

        //public IActionResult OnGetChangePassword(long id)
        //{
        //    var command = new ChangePassword { Id = id };
        //    return Partial("ChangePassword", command);
        //}

        //public JsonResult OnPostChangePassword(ChangePassword command)
        //{
        //    var result = _accountApplication.ChangePassword(command);
        //    return new JsonResult(result);
        //}
    }
}
