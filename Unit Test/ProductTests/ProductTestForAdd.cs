using Business.Abstract;
using Business.ValidationAspect.FluentValidation;
using Entities.Concrete;
using Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Test.ProductTests
{
    public class ProductTestForAdd
    {
        IProductService _productService;
        ProductForAddValidator validationRules;
        public ProductTestForAdd(IProductService productService)
        {
            _productService = productService;
            validationRules = new ProductForAddValidator();
        }
        [Fact]
        public void ProductAddTest()
        {
            var productForAdd = new ProductForAddDto()
            {
                BrandId = 1,
                Description = "description of product",
                Name = "name of product",
                ProductCode = "TEST0101PRODUCT",
                QuantityPerUnit = "ADET",
                UnitsInStock = 23,
                UnitPrice = 54,
            };
            var result = validationRules.Validate(productForAdd);
            Assert.True(result.Errors.Any());
        }
    }
}
