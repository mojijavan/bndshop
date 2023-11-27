
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                CustomerDiscountRate = x.CustomerDiscountRate,
                CustomerUnitPrice = x.CustomerUnitPrice,
                ColleagueDiscountRate = x.ColleagueDiscountRate,
                ColleagueUnitPrice = x.ColleagueUnitPrice,
                Count = x.Count,
                CreationDate = x.CreationDate.ToString(),
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId,
                    CreationDate = x.CreationDate.ToString(),
                    Code = x.Code,
                    Count = x.Count,
                    IsInStock = x.IsInStock,
                    Picture = x.Picture,
                    CustomerDiscountRate = x.CustomerDiscountRate,
                    CustomerUnitPrice = x.CustomerUnitPrice,
                    ColleagueDiscountRate = x.ColleagueDiscountRate,
                    ColleagueUnitPrice = x.ColleagueUnitPrice
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.Code!=0)
                query = query.Where(x => x.Code==searchModel.Code);

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
