﻿using System.Collections.Generic;

namespace _01_BndShopQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> LatestArticles();
        ArticleQueryModel GetArticleDetails(string slug);
    }
}
