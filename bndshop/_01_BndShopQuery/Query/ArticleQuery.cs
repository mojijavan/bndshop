﻿using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Article;
using _01_BndShopQuery.Contracts.Comment;
using BlogManagement.Infrastructure.EFCore;
using CommnetManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01_BndShopQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
               .Include(x => x.Category)
               //.Where(x => x.PublishDate <= DateTime.Now)
               .Select(x => new ArticleQueryModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   CategoryName = x.Category.Name,
                   CategorySlug = x.Category.Slug,
                   Slug = x.Slug,
                   CanonicalAddress = x.CanonicalAddress,
                   Description = x.Description,
                   Keywords = x.Keywords,
                   MetaDescription = x.MetaDescription,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   PublishDate = x.PublishDate.ToFarsi(),
                   ShortDescription = x.ShortDescription,
               }).FirstOrDefault(x => x.Slug == slug);
            if (article == null) return article;
            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split(",").ToList();


            var comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                    comment.parentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
            }

            article.Comments = comments;

            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {

            //var articles = _context.Articles.ToList();
            //foreach (var article in articles)
            //{
            //    article.changeData(article);
            //    _context.SaveChanges();
            //}
            return _context.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Id=x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();
        }
    }
}
