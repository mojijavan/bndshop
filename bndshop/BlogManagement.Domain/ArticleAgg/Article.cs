
using _0_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory Category { get; private set; }

        public Article()
        {
            PublishDate=DateTime.Now;
            
        }

        public void changeData(Article article)
        {
            Title = article.Title.Replace("بندرموبایل", "بندرپلاس");
            Description = article.Description.Replace("بندرموبایل", "بندرپلاس");
            ShortDescription = article.ShortDescription.Replace("بندرموبایل", "بندرپلاس");
            PictureAlt = article.PictureAlt.Replace("بندرموبایل", "بندرپلاس");
            PictureTitle = article.PictureTitle.Replace("بندرموبایل", "بندرپلاس");
            Slug = article.Slug.Replace("بندرموبایل", "بندرپلاس");
            Keywords = article.Keywords.Replace("بندرموبایل", "بندرپلاس");
            MetaDescription = article.MetaDescription.Replace("بندرموبایل", "بندرپلاس");
           
        }

        public Article(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string slug,
            string keywords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }

        public void Edit(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string slug,
            string keywords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
