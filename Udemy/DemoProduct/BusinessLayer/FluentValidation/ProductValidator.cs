using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok sayısı boş olamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş olamaz.");
        }
    }
}
