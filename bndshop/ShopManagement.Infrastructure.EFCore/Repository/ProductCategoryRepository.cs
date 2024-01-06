using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository:RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _context = context;
        }

       
        public EditProductCategory GetDetails(long id)
        {
            var x= _context.ProductCategories.Where(x => x.Id == id).Select(x => new EditProductCategory()
            {
                Id = x.Id,Description = x.Description,Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,Name = x.Name,/*Picture ="",*/
                PictureAlt = x.PictureAlt,Slug = x.Slug,PictureTitle = x.PictureTitle
                ,Code = x.Code,LastProductCode = x.LastProductCode,
                ParentId = x.ParentId,
                Label = x.Label
            }).FirstOrDefault();
            return x;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Code = x.Code,
                CreationDate = x.CreationDate.ToString(),
                Name = x.Name,
                ParentId = x.ParentId,
                Priority = x.Priority,
                Picture = x.Picture
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.ParentId!=0)
                query = query.Where(x => x.ParentId==searchModel.ParentId);
            return query.OrderByDescending(x => x.Id).ToList();

        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x=>new ProductCategoryViewModel
            {
                Id=x.Id,Name = x.Name,ParentId = x.ParentId
            }).ToList();
        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.Id == id).Slug;
        }

        public int GetNewProductCategoryCodeById()
        {
            var MaxCode = _context.ProductCategories.Max(x => x.Code);
            if (MaxCode != null)
            {
                if (MaxCode != 0)
                    return MaxCode + 1;
            }
            return 100;
        }

        public string GetCategoryAndFatherLabel(long id)
        {
            var category = _context.ProductCategories.FirstOrDefault(x => x.Id==id);
            return  category.Label +"،"+ _context.ProductCategories.FirstOrDefault(x => x.Id == category.ParentId).Label;
        }

        public int GetNewProductCodeById(long id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.Id == id).LastProductCode + 1;
        }

    }
}
