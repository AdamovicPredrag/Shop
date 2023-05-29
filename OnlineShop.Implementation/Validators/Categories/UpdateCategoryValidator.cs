using FluentValidation;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.States;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CategoryName).NotEmpty().MinimumLength(2).Must((request, n) => !_context.States.Any(x => x.Name == request.CategoryName && x.Id != request.Id));
        }
    }
}
