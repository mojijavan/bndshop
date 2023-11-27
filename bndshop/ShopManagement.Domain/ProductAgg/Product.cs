
using System;
using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;


namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; private set; }
        public int Code { get; private set; }
        public bool IsInStock { get; private set; }
        public int CustomerDiscountRate { get; private set; }
        public int ColleagueDiscountRate { get; private set; }
        public double CustomerUnitPrice { get; private set; }
        public double UnitPrice { get; private set; }
        public double ColleagueUnitPrice { get; private set; }
        public long Count { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description  { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<ProductPicture> ProductPictures { get; set; }
        
        public Product()
        {
            ProductPictures = new List<ProductPicture>();
            
        }

        public Product(string name, int code, 
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords,
            string metaDescription, long categoryId,double unitPrice)
        {
            Name = name;
            Code = code;
            CustomerDiscountRate = 0;
            CustomerUnitPrice = unitPrice;
            ColleagueDiscountRate = 0;
            ColleagueUnitPrice = unitPrice;
            Count = 0;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            IsInStock = false;
            PictureAlt = pictureAlt;
            IsInStock = true;
            UnitPrice = unitPrice;
            CreationDate=DateTime.Now;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void Edit(string name, int code,  string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string metaDescription, long categoryId,long count,double unitPrice)
        {
            Name = name;
            Code = code;
            UpdatePrice(unitPrice);
            //UpdateCustomerDiscountRate(CustomerDiscountRate);
            //UpdateColleagueDiscountRate(ColleagueDiscountRate);
            UpdateCount(count);
            ShortDescription = shortDescription;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }

        public void UpdateCount(long count)
        {
            Count = count;
            if (Count > 0) IsInStock = true;
            else IsInStock = false;

        }
        public void UpdatePrice(double price)
        {
            UnitPrice = price;
            UpdateCustomerDiscountRate(CustomerDiscountRate);
            UpdateColleagueDiscountRate(ColleagueDiscountRate);
        }
        public void UpdateCustomerDiscountRate(int customerDiscountRate)
        {
            CustomerDiscountRate = customerDiscountRate;
            if (CustomerDiscountRate > 0)
            {
                
                var discountAmount = Math.Round((UnitPrice * CustomerDiscountRate) / 100);
                CustomerUnitPrice = (UnitPrice - discountAmount);
                if (ColleagueDiscountRate < CustomerDiscountRate)
                {
                    ColleagueDiscountRate = CustomerDiscountRate;
                    ColleagueUnitPrice = CustomerUnitPrice;
                }
            }
            else
            {
                CustomerUnitPrice = UnitPrice;
            }
           
        }
        public void UpdateColleagueDiscountRate(int colleagueDiscountRate)
        {
            ColleagueDiscountRate = colleagueDiscountRate;
            if (ColleagueDiscountRate > 0)
            {
                var discountAmount = Math.Round((UnitPrice * ColleagueDiscountRate) / 100);
                ColleagueUnitPrice = (UnitPrice - discountAmount);
                if (ColleagueDiscountRate < CustomerDiscountRate)
                {
                    ColleagueDiscountRate = CustomerDiscountRate;
                    ColleagueUnitPrice = CustomerUnitPrice;
                }
            }
            else
            {
                ColleagueUnitPrice = UnitPrice;
            }
        }
    }
}
