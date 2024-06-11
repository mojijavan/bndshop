
using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;


namespace ShopManagement.Application
{
   public class ProductCategoryApplication: IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            OperationResult operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = $"/ProductPictures//{slug}";
            var FileName = _fileUploader.Upload(command.Picture, path);
            var code = GetCodeForCreate();
            var ProductCategory = new ProductCategory(command.Name, command.Description, FileName,
                                        command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug,code,command.ParentId,command.Priority,command.Label,command.Specifications);
            _productCategoryRepository.Create(ProductCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command) 
        {
            var productCategory = _productCategoryRepository.Get(command.Id);
            OperationResult operation = new OperationResult();
            if (productCategory==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name&&x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = $"/ProductPictures//{slug}";
            var FileName = _fileUploader.Upload(command.Picture,path);
            productCategory.Edit(command.Name, command.Description, FileName,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug,command.Code,command.LastProductCode,command.ParentId,command.Priority,command.Label,command.Specifications);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            productCategory.Remove();
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            productCategory.Restore();
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public string GetCategoryAndFatherLabel(long id)
        {
            throw new System.NotImplementedException();
        }

        public int GetCodeForCreate()
        {
            return _productCategoryRepository.GetNewProductCategoryCodeById();
        }

        public OperationResult UpdateLastProductCode(long id, int lastProductCode)
        {
            var productCategory = _productCategoryRepository.Get(id);
            OperationResult operation = new OperationResult();
            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            
            productCategory.EditLastProductCode(lastProductCode);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(ProductCategoryViewModel command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            if (!_productCategoryRepository.Exists(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
            _productCategoryRepository.Delete(command.Id);
            operation = _fileUploader.DeleteFolder(command.Picture);
            _productCategoryRepository.SaveChanges();
            return operation;
        }
    }
}
