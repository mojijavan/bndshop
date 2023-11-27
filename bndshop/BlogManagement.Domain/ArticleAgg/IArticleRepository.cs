using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;
using System.Collections.Generic;
using _0_Framework.Application;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetDetails(long id);
        Article GetWithCategory(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
        ArticleViewModel GetViewModelWith(long id);
      
    }
}
