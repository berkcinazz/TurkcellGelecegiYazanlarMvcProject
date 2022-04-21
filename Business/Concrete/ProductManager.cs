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
    }
}
