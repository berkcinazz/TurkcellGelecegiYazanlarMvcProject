using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductForListingDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool OnSale { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public double ReviewPoint { get; set; }
        public int ReviewCount { get; set; }
        public Entities.Concrete.Brand Brand { get; set; }
        public Concrete.ProductImage MainImage { get; set; }
    }
}
