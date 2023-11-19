using _01_BndShopQuery.Contracts.Comment;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using ShopManagement.Domain.ProductPictureAgg;


namespace _01_BndShopQuery.Contracts.Product
{
    public class ProductQueryModel
    {
       
        public ProductQueryModel( )
        {
            
            Comments = new List<CommentQueryModel>();
            Pictures = new List<ProductPictureQueryModel>();
        }

        public ProductQueryModel(ShopManagement.Domain.ProductAgg.Product product,bool IsColleagueUser)
        {
            //ProductQueryModel productQueryModel = new ProductQueryModel();
            Id = product.Id;
            Category = product.Category.Name;
            Name = product.Name;
            Picture = product.Picture;
            PictureAlt = product.PictureAlt;
            PictureTitle = product.PictureTitle;
            Slug = product.Slug;
            CategorySlug = product.Category.Slug;
            Code = product.Code;
            Description = product.Description;
            Keywords = product.Keywords;
            IsInStock = product.IsInStock;
            MetaDescription = product.MetaDescription;
            ShortDescription = product.ShortDescription;
            Pictures = MapProductPictures(product.ProductPictures);
            UnitPrice = product.UnitPrice.ToMoney();
            
            if (IsColleagueUser)
            {
                if (product.UnitPrice > product.ColleagueUnitPrice)
                    HasDiscount = true;
                PriceWithDiscount = product.ColleagueUnitPrice.ToMoney();
                DoublePriceWithDiscount = product.ColleagueUnitPrice;
                DiscountRate = product.ColleagueDiscountRate;
            }
            else
            {
                if (product.UnitPrice > product.CustomerUnitPrice)
                    HasDiscount = true;
                PriceWithDiscount = product.CustomerUnitPrice.ToMoney();
                DoublePriceWithDiscount = product.CustomerUnitPrice;
                DiscountRate = product.CustomerDiscountRate;
            }

            //return productQueryModel;
        }
        private List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            if (pictures == null) return new List<ProductPictureQueryModel>();
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }
 

        public string UnitPrice { get; set; }
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
       
        public int DiscountRate { get; set; }
        public double DoublePriceWithDiscount { get; set; }
        
        public string PriceWithDiscount { get; set; }
        public string Category { get; set; }
        public string CategorySlug { get; set; }
        public string DiscountExpireDate { get; set; }
        public int Code { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsInStock { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
        public bool HasDiscount { get; set; }
       
    }

}
