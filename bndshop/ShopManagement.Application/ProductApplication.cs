
using System.Collections.Generic;

using _0_Framework.Application;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
   public class ProductApplication:IProductApplication
   {
       private readonly IProductRepository _productRepository; 
       private readonly IFileUploader _fileUploader;
       private readonly IProductCategoryRepository _productCategoryRepository;
       private readonly InventoryContext _inventoryContext;
       private readonly DiscountContext _discountContext;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

       public OperationResult Create(CreateProduct command)
       {
           
           var operation = new OperationResult();
           if (_productRepository.Exists(x => x.Name == command.Name))
               return operation.Failed(ApplicationMessages.DuplicatedRecord);
           var slug = command.Slug.Slugify();
           var categorySlug = _productCategoryRepository.GetSlugById(command.CategoryId);
           
            var path = $"/ProductPictures//{categorySlug}//{slug}";
            var Code = _productCategoryRepository.GetNewProductCodeById(command.CategoryId);
            var picturePath = _fileUploader.Upload(command.Picture, path);
            
            var product = new Product(command.Name, Code, command.ShortDescription,
               command.MetaDescription, picturePath
               , command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription,
               command.CategoryId,command.UnitPrice,command.Label);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            var ProductCategory = _productCategoryRepository.Get(product.CategoryId);
            ProductCategory.EditLastProductCode(Code);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
       }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductWithCategory(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = $"/ProductPictures//{product.Category.Slug}//{slug}";
            //var path = $"{product.Category.Slug}//{slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            //var FileName = _fileUploader.Upload(command.Picture, slug);              
            product.Edit(command.Name, command.Code, command.ShortDescription,
                command.MetaDescription, picturePath
                , command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription,
                command.CategoryId,command.Count,command.UnitPrice,command.Label);
            _productRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditProduct GetDetails(long id)
        {
            EditProduct editProduct= _productRepository.GetDetails(id);
            editProduct.ParentLabel = _productCategoryRepository.GetCategoryAndFatherLabel(editProduct.CategoryId);
            return editProduct;
        }

        public OperationResult IsStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
           
            
            product.InStock();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.NotInStock();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.Remove();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.Restore();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OperationResult UpdatePrice(long id, double unitPrice)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.UpdatePrice(unitPrice);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }
        //public OperationResult Remove(long id)
        //{
        //    var operation = new OperationResult();
        //    var Product= _productRepository.Get(id);
        //    if (Product == null)
        //        return operation.Failed(ApplicationMessages.RecordNotFound);
        //    Product.Remove();
        //    _productPictureRepository.SaveChanges();
        //    return operation.Succedded();
        //}
        public OperationResult UpdateCount(long id, long count)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.UpdateCount(count);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }


        public OperationResult UpdateCustomerDiscountRate(long id, int customerDiscountRate)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.UpdateCustomerDiscountRate(customerDiscountRate);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult UpdateColleagueDiscountRate(long id, int colleagueDiscountRate)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.UpdateColleagueDiscountRate(colleagueDiscountRate);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(ProductViewModel command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            if (!_productRepository.Exists(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
            _productRepository.Delete(command.Id);
            operation = _fileUploader.DeleteFolder(command.Picture);
            _productRepository.SaveChanges();
            return operation;
        }
    }
}
