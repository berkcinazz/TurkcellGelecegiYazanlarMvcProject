using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.UserBasketProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserBasketProductService
    {
        IDataResult<List<UserBasketProductsForListingDTO>> GetAllProductsFromBasket();
        IResult AddProductToBasket(UserBasketProductsForAddDTO userBasketProduct);
        IResult UpdateProductFromBasket(UserBasketProductsForUpdateDTO userBasketProduct);
        IResult DeleteProductFromBasket(int id);
        IDataResult<UserBasketProduct> GetBasketItemByProductId(int productId);
    }
}
