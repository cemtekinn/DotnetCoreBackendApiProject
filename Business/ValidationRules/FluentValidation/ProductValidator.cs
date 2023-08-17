using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
       
        public ProductValidator()
        {
            
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            
           // RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("Ürünler A harfi başlamalıdır");
        }

        //Örnek
        private bool StartsWithA(string arg)
        {
            if (arg.StartsWith('A')) return true;
            else return false;
        }
    }
}
