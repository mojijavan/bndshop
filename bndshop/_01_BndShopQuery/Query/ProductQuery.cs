using _0_Framework.Application;
using _01_BndShopQuery.Contracts.Comment;
using _01_BndShopQuery.Contracts.Product;
using CommnetManagement.Infrastructure.EFCore;

using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.ProductAgg;

namespace _01_BndShopQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;
        private readonly IAuthHelper _authHelper;
        public ProductQuery(ShopContext context, CommentContext commentContext, InventoryContext inventoryContext, DiscountContext discountContext, IAuthHelper authHelper)
        {
            _context = context;
            _commentContext = commentContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
           
            var product = _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)

                .Select(x=>x).AsNoTracking().FirstOrDefault(x => x.Slug == slug);
            
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            ProductQueryModel productQueryModel = new ProductQueryModel(product, IsColleagueUser);
            
            productQueryModel.Comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            if (product == null)
                return new ProductQueryModel();
            return productQueryModel;
        }
   
        //private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        //{
        //    if (pictures == null) return new List<ProductPictureQueryModel>();
        //    return pictures.Select(x => new ProductPictureQueryModel
        //    {
        //        IsRemoved = x.IsRemoved,
        //        Picture = x.Picture,
        //        PictureAlt = x.PictureAlt,
        //        PictureTitle = x.PictureTitle,
        //        ProductId = x.ProductId
        //    }).Where(x => !x.IsRemoved).ToList();
        //}
        public SlickSliderModel SlickSlider(string id)
        {
            SlickSliderModel slickSliderModel = new SlickSliderModel();
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var products = new List<Product>();
            if (id == "LatestArrivals")
            {
                products = _context.Products.Include(x => x.Category)
                    .Where(x => x.IsInStock).Select(product => product).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();
                slickSliderModel.Title = "جدید ترین محصولات";
                slickSliderModel.SubTitle = "";
            }

            if (id == "GetPishnahadVizhe")
            {
                products = _context.Products.Include(x => x.Category)
                    .Where(x => x.IsInStock).Select(product => product).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();
                slickSliderModel.Title = "پیشنهاد ویژه";
                slickSliderModel.SubTitle = "";
            }

            if (id == "MaxDiscount")
            {
                products = _context.Products.Include(x => x.Category)
                    .Where(x => x.IsInStock&&x.CustomerDiscountRate>0).Select(product => product).AsNoTracking().OrderByDescending(x => x.CustomerDiscountRate).Take(6).ToList();
                slickSliderModel.Title = "بیشترین تخفیفات";
                slickSliderModel.SubTitle = "";
            }
            //List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            slickSliderModel.ProductQueryModels = MapProducts(products, IsColleagueUser);
            if (slickSliderModel.ProductQueryModels.Count == 0) slickSliderModel.IsShow = false;
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.EndDate, x.ProductId }).ToList();
            foreach (var productQueryModel in slickSliderModel.ProductQueryModels)
            {
                var discount = discounts.FirstOrDefault(x => x.ProductId == productQueryModel.Id);
                    if (discount != null)
                    {
                        productQueryModel.DiscountExpireDate = discount.EndDate.ToFarsi();
                    }
            }

            return slickSliderModel;

        }
        private static List<ProductQueryModel> MapProducts(List<Product> products, bool IsColleagueUser)
        {
            List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            foreach (var product in products)
            {
                productQueryModels.Add(new ProductQueryModel(product, IsColleagueUser));
            }
            return productQueryModels.ToList();
        }
        public List<ProductQueryModel> GetPishnahadVizhe()
        {
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var products = _context.Products.Include(x => x.Category)
                .Where(x=>x.IsInStock).Select(product => product).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();
            List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            productQueryModels = MapProducts(products, IsColleagueUser);
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.EndDate, x.ProductId }).ToList();
            foreach (var productQueryModel in productQueryModels)
            {
                var discount = discounts.FirstOrDefault(x => x.ProductId == productQueryModel.Id);
                if (discount != null)
                {
                    productQueryModel.DiscountExpireDate = discount.EndDate.ToFarsi();
                }
            }

            return productQueryModels;
        }

        public List<ProductQueryModel> Search(string value)
        {
            bool IsColleagueUser = false;
            IsColleagueUser = _authHelper.IsColleagueUser();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x =>x).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));
            List<ProductQueryModel> productQueryModels = new List<ProductQueryModel>();
            productQueryModels = MapProducts(query.ToList(), IsColleagueUser);
           
            return productQueryModels.OrderByDescending(x => x.Id).ToList();
        }

        public List<CartItem> CheckInventoryStatus(List<CartItem> cartItems)
        {
            var inventory = _inventoryContext.Inventory.ToList();

            foreach (var cartItem in cartItems.Where(cartItem =>
                inventory.Any(x => x.ProductId == cartItem.Id && x.InStock)))
            {
                var itemInventory = inventory.Find(x => x.ProductId == cartItem.Id);
                cartItem.IsInStock = itemInventory.CalculateCurrentCount() >= cartItem.Count;
            }

            return cartItems;
        }
    }
}