
using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;


namespace ShopManagement.Application
{
   public class ProductCategoryApplication: IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        
        }

        public OperationResult Create(CreateProductCategory command)
        {
            OperationResult _operationResult = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return _operationResult.Failed("نام رکورد تکراری می باشد. دوباره تلاش کنید");
            var slug = command.Slug.Slugify();
            var ProductCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                                        command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.Create(ProductCategory);
            _productCategoryRepository.SaveChanges();
            return _operationResult.Succeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var productCategory = _productCategoryRepository.Get(command.Id);
            OperationResult _operationResult = new OperationResult();
            if (productCategory==null)
                return _operationResult.Failed("گزینه مورد نظر یافت نشد. دوباره تلاش کنید");
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name&&x.Id!=command.Id))
                return _operationResult.Failed("نام رکورد تکراری می باشد. دوباره تلاش کنید");
            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();
            return _operationResult.Succeded();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }
    }
}
