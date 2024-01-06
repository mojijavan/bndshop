
using System.Collections.Generic;

using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
   public class ProductPictureApplication:IProductPictureApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"/ProductPictures//{product.Category.Slug}//{product.Slug}";
           // var path = $"{product.Category.Slug}//{product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var productPicture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var ProductPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (ProductPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            var path = $"/ProductPictures//{ProductPicture.Product.Category.Slug}//{ProductPicture.Product.Slug}";
            //var path = $"{ProductPicture.Product.Category.Slug}//{ProductPicture.Product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            ProductPicture.Edit(command.ProductId,picturePath,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
            
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            ProductPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            ProductPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}
