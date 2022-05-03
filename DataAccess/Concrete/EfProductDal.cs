using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfProductDal : EFRepositoryBase<Product, EFCoreContext>, IProductDal
    {
        public List<ProductForListingDTO> GetAllProducts()
        {
            using (var context = new EFCoreContext())
            {
               
                var result = context.Products.Include(i => i.Brands).Include(i => i.ProductImages).Include(i=>i.UserFavorites).Select(p => new ProductForListingDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brands,
                    Description = p.Description,
                    MainImage = p.ProductImages.Where(i => i.IsMainImage).FirstOrDefault(),
                    OnSale = p.OnSale,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    ProductCode = p.ProductCode,
                    IsUserFavorite = (p.UserFavorites.ProductId == p.Id ? true : false)
                });
                return result.ToList();
            }
        }
    }
}
