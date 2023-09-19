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
                MetaDescription = x.MetaDescription,Name = x.Name,Picture = x.Picture,
                PictureAlt = x.PictureAlt,Slug = x.Slug,PictureTitle = x.PictureTitle

            }).FirstOrDefault();
            return x;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(),
                Name = x.Name,
                Picture = x.Picture
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
