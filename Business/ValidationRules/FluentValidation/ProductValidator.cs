using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //Tüm kurallarımızı buraya yazıyoruz.
        // ctrl k + ctrl d >> Kodları düzenler.
        // Validator 19 farklı dilde dester veriyor.
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); // Productın name'i 2 karakter olmalıdır.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg) // Ruleforda olmayan kuralları kendimiz Must ile metodlaştırıp yazabiliriz.
        {
            return arg.StartsWith("A");
        }
    }
}
