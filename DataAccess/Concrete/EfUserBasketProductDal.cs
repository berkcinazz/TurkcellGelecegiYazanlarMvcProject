using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.UserBasketProduct;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserBasketProductDal : EFRepositoryBase<UserBasketProduct, EFCoreContext>, IUserBasketProductDal
    {
        public List<UserBasketProductsForListingDTO> GetAllProductInUserBasket(int userBasketId)
        {
            using (var context = new EFCoreContext())
            {
                var rr = context.UserBasketProducts.Include(i => i.UserBasket).Include(i => i.Product).Where(i=>i.UserBasketId==userBasketId).Select(p => new UserBasketProductsForListingDTO()
                {
                    Id = p.Id,
                    Product = p.Product,
                    Quantity = p.Quantity,
                    UserBasket = p.UserBasket
                });
                return rr.ToList();
            }
        }
    }
}
