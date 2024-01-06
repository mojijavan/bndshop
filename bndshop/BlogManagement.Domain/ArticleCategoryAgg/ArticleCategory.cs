using _0_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public int ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string description, int showOrder, string slug, string keywords, string metaDescription,
            string canonicalAddress)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }

        public void changeData(ArticleCategory article)
        {
            Name = article.Name.Replace("بندرموبایل", "بندرپلاس");
            PictureAlt = article.PictureAlt.Replace("بندرموبایل", "بندرپلاس");
            PictureTitle = article.PictureTitle.Replace("بندرموبایل", "بندرپلاس");
            Description = article.Description.Replace("بندرموبایل", "بندرپلاس"); 
            Slug = article.Slug.Replace("بندرموبایل", "بندرپلاس"); 
            Keywords = article.Keywords.Replace("بندرموبایل", "بندرپلاس");
            MetaDescription = article.MetaDescription.Replace("بندرموبایل", "بندرپلاس");
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description, int showOrder,
            string slug, string keywords, string metaDescription, string canonicalAddress)
        {
            Name = name;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }
    }
}
