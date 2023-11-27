using _0_Framework.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        ArticleViewModel GetArticleViewModelWith(long id);
        OperationResult Edit(EditArticle command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
        OperationResult Delete(ArticleViewModel Id);
    }
}
