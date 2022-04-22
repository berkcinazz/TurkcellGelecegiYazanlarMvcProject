﻿using Core.DataAccess.EntityFramework;
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
               
                var result = context.Products.Include(i => i.Brand).Include(i => i.ProductImages).Include(i => i.ProductReviews).Select(p => new ProductForListingDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Description = p.Description,
                    MainImage = p.ProductImages.Where(i => i.IsMainImage).FirstOrDefault(),
                    OnSale = p.OnSale,
                    QuantityPerUnit = p.QuantityPerUnit,
                    ReviewCount = p.ProductReviews.Count,
                    ReviewPoint = (double)p.ProductReviews.Sum(i => i.Stars) / (double)p.ProductReviews.Count,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                });
                return result.ToList();
            }
        }
    }
}