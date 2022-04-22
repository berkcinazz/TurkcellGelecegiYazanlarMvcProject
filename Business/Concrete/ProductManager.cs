using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult AddNewProduct(ProductForAddDto productToAdd)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteProduct(int productId)
        {
            var product = _productDal.Get(p => p.Id == productId);
            if (product == null) { return new ErrorResult(Messages.ProductNotFound); }
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<ProductForListingDTO>> GetAllProducts()
        {
            var result = _productDal.GetAllProducts();
            return new SuccessDataResult<List<ProductForListingDTO>>(result);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            var result = _productDal.Get(p => p.Id == productId);
            if (result == null) return new ErrorDataResult<Product>(Messages.ProductNotFound);
            return new SuccessDataResult<Product>(result);
        }

        public IResult UpdateProduct(ProductForUpdateDto product)
        {
            var productToUpdate = _productDal.Get(p => p.Id == product.Id);
            if (productToUpdate == null) { return new ErrorResult(Messages.ProductNotFound); }
            productToUpdate.Name = product.Name;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.Description = product.Description;
            productToUpdate.Active = product.Active;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.ProductCode = product.ProductCode;
            productToUpdate.QuantityPerUnit = product.QuantityPerUnit;
            productToUpdate.OnSale = product.OnSale;
            productToUpdate.BrandId = product.BrandId;
            _productDal.Update(productToUpdate);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
