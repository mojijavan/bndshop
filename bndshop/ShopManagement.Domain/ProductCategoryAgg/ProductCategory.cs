
using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;


namespace ShopManagement.Domain.ProductCategoryAgg
{
   public class ProductCategory: EntityBase
    {
        public string Name { get;private set; }
        public string Description { get;private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public int Code { get; private set; }
        public int LastProductCode { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Product>Products { get; private set; }
        public long ParentId { get; private set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle, string keywords, string metaDescription, string slug,int code,long parentId)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Code = code;
            ParentId = 0;
            LastProductCode = (code * 10000);
            ParentId = parentId;
        }
        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string keywords, string metaDescription, string slug,int code,int lastProductCode,long parentId)
        {
            Name = name;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Code = code;
            ParentId = parentId;
            LastProductCode = lastProductCode;
        }
        public void EditLastProductCode(int lastProductCode)
        {
            LastProductCode = lastProductCode;
        }
    }
}
