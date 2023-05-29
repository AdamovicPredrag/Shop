using FluentValidation;
using OnlineShop.Application.Requests.Product;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty().NotEmpty().Must(cat => _context.Categories.Any(x => x.Id == cat)).WithMessage("Category is not valid.");
            RuleFor(x => x.IdShop).NotEmpty().NotEmpty().Must(cat => _context.Shops.Any(x => x.Id == cat)).WithMessage("Shop is not valid.");
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
        }
    }
}
