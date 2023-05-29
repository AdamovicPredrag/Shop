using FluentValidation;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Categories
{
    public class AddCategoryValidator:AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(x => !_context.Categories.Any(c => c.Name == x)).WithMessage("Category name must be unique!");
        }
    }
}
