using Entities.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationAspect.FluentValidation
{
    public class ProductForAddValidator:AbstractValidator<ProductForAddDto>
    {
        public ProductForAddValidator()
        {
            RuleFor(i => i.UnitPrice).NotEmpty().NotNull().GreaterThan(0).WithMessage("Ücret 0'dan büyük olmalıdır.");
            RuleFor(i => i.BrandId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Marka seçilmelidir.");
            RuleFor(i => i.UnitsInStock).NotEmpty().NotNull().GreaterThan(0).WithMessage("Stok adedi 0'dan büyük olmalıdır.");
            RuleFor(i => i.Name).NotEmpty().NotNull().MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.");
        }
    }
}
