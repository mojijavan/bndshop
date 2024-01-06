using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Product;
using _01_BndShopQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Org.BouncyCastle.Math.EC.Rfc7748;
using ShopManagement.Domain.ProductPictureAgg;

namespace _01_BndShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
      
        private readonly IAuthHelper _authHelper;
        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext, IAuthHelper authHelper)
        {
            _context = context;
            _discountContext = discountContext;
            _authHelper = authHelper;
            _inventoryContext = inventoryContext;

        }

       
        public long GetIdWith(string slug)
        {
            return _context.ProductCategories.Where(x=>x.Slug==slug).Select(x=>x.Id).FirstOrDefault();
        }

        public List<ProductCategoryTopRefrence> GetTopList(string parentSlug, string slug, string label)
        {
           
            if (label != null)
            {
                var query = _context.ProductCategories
                    .Where(x => x.Label.Contains(label) && x.IsRemoved == false)
                    .Select(x => new ProductCategoryTopRefrence()
                    {
                        PName = x.Name,
                        Slug = x.Slug,
                        Label = "",
                        ParentSlug = parentSlug,
                    });
                return query.ToList();
            }
            else
            {
                if (slug == null)
                {
                    var id = GetIdWith(parentSlug);
                    return _context.ProductCategories
                        .Where(x => x.ParentId == id && x.IsRemoved == false)
                        .Select(x => new ProductCategoryTopRefrence()
                        {
                            Id = x.Id,
                            PName = x.Name,
                            Label = "",
                            Slug = x.Slug,
                            ParentSlug = parentSlug
                        }).ToList();
                }
                else
                {
                    var id = GetIdWith(slug);
                    var mylabel= _context.ProductCategories
                        .Where(x => x.Id == id && x.IsRemoved == false)
                        .Select(x => x.Label).FirstOrDefault();
                    var query = new List<ProductCategoryTopRefrence>();
                    if (mylabel != null)
                    {
                        var labelList = mylabel.Split('،');

                        foreach (var s in labelList)
                        {
                            query.Add(new ProductCategoryTopRefrence
                            {
                                ParentSlug = parentSlug,
                                Slug = slug,
                                Label = s,
                                PName = s
                            });
                        }

                    }

                    return query;
                }
               
            }
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Where(x=>x.ParentId==0&&x.IsRemoved==false).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }
      
        public List<ProductCategoryQueryModel> GetProductCategoryWithParent(string slug)
        {
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            var id = GetIdWith(slug);
            var categories = _context.ProductCategories
                
                .Include(x => x.ProductCategories)
                .Where(x => x.ParentId == id && x.IsRemoved == false)
                .Include(a => a.Products)
                
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products, IsColleagueUser,null)
                }).AsNoTracking().ToList();//FirstOrDefault(x => x.Slug == slug);
            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    }
                }
            }
            
            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products,bool IsColleagueUser,string label)
        {
            List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            foreach (var product in products)
            {
                if (label != null && product.IsRemoved == false)
                {
                    if (product.Label != null)
                    {
                        if (product.Label.Contains(label))
                            productQueryModels.Add(new ProductQueryModel(product, IsColleagueUser));
                    }
                    
                }
                else
                    productQueryModels.Add(new ProductQueryModel(product,IsColleagueUser));
            }
            return productQueryModels.OrderByDescending(x => x.Id).Take(12).ToList();
           
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug,string label)
        {
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            
            var category = _context.ProductCategories
                .Include(a => a.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products,IsColleagueUser,label)
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);
            if (category != null)
            {
                foreach (var product in category.Products)
                {
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    }
                }
            }
            else
            {
                category = new ProductCategoryQueryModel();
                category.Products = new List<ProductQueryModel>();
            }
            
            return category;
        }
        //public List<ProductCategoryQueryModel> GetProductCategoryChildWith(string slug)
        //{
        //    var id = GetIdWith(slug);
        //    return _context.ProductCategories
        //        .Where(x => x.ParentId == id)
        //        .Select(x => new ProductCategoryQueryModel()
        //        {
        //            Name = x.Name, Slug = slug+"/"+x.Slug
        //        }).AsNoTracking().ToList();
        //}
        //private ProductQueryModel MapProduct(Product x)
        //{
        //    if (_authHelper.IsColleagueUser())
        //    {
        //        return new ProductQueryModel(x.Id, x.Category.Name, x.Name, x.IsInStock,
        //            x.Picture, x.PictureAlt, x.PictureTitle, x.Slug, x.UnitPrice, x.ColleagueUnitPrice, x.ColleagueDiscountRate, x.ProductPictures);
        //    }
        //    return new ProductQueryModel(x.Id, x.Category.Name, x.Name, x.IsInStock,
        //        x.Picture, x.PictureAlt, x.PictureTitle, x.Slug, x.UnitPrice, x.CustomerDiscountRate, x.CustomerDiscountRate, x.ProductPictures);
        //}


        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var categories = _context.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,

                    Products = MapProducts(x.Products, IsColleagueUser, null)
                }).OrderByDescending(x => x.Id).Take(6).ToList();//.AsNoTracking().ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    }
                }
            }
            return categories;
        }

    }
}
