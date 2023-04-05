using Akanay.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.ProductName).Must(StartWithA).WithMessage("Ürün adı A harfi ile başlamalıdır");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(1).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.CategoryId == 1).WithMessage("Kategori 1 için ürün fiyatı 10'dan büyük olmalıdır");
            RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage("Stok adedi boş geçilemez");
            RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stok adedi 0'dan büyük veya eşit olmalıdır");
        }

        private bool StartWithA(string arg)
        {
           return arg.StartsWith("A");
        }
    }
}
