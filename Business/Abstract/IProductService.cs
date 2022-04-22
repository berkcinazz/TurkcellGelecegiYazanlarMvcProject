using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductForListingDTO>> GetAllProducts();
        IResult AddNewProduct(ProductForAddDto productToAdd);
        IResult DeleteProduct(int productId);
        IDataResult<Product> GetProductById(int productId);
        IResult UpdateProduct(ProductForUpdateDto product);
    }
}
