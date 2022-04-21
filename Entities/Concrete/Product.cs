﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public partial class Product : IEntity
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
            ProductReviews = new List<ProductReview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public string CommonCode { get; set; }
        public bool OnSale { get; set; }
        public int? SalePercantage { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public string Description { get; set; }
        public decimal ShippingCost { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductReview> ProductReviews { get; set; }
    }
}
