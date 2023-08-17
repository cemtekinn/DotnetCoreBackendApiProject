using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName).NotEmpty();
            

            // RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("Ürünler A harfi başlamalıdır");
        }
    }
}
