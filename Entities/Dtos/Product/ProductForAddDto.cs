using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductForAddDto : IDto
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
    }
}
