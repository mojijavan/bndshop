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

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }
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
                    Products = MapProducts(x.Products,IsColleagueUser)
                }).AsNoTracking().ToList();

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

        private static List<ProductQueryModel> MapProducts(List<Product> products,bool IsColleagueUser)
        {
            List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            foreach (var product in products)
            {
                productQueryModels.Add(new ProductQueryModel(product,IsColleagueUser));
            }
            return productQueryModels.ToList();
           
        }

        public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
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
                    Products = MapProducts(x.Products,IsColleagueUser)
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            foreach (var product in category.Products)
            {
                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (discount != null)
                {
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                }
            }
            return category;
        }
    }
}
