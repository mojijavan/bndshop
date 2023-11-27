using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;

        public DeleteModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        [BindProperty]
        public ArticleViewModel command { get; set; }
        public  void OnGet(long id)
        {
            command = _articleApplication.GetArticleViewModelWith(id);
           
        }
        public IActionResult OnPost()
        {
            var result = _articleApplication.Delete(command);
            return RedirectToPage("./index");
        }
    }
}
