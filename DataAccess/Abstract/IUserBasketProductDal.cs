using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.UserBasketProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserBasketProductDal : IRepositoryBase<UserBasketProduct>
    {
        List<UserBasketProductsForListingDTO> GetAllProductInUserBasket(int userId);
    }
}
