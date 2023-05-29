using FluentValidation;
using OnlineShop.Application.Requests.Cart;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Cart
{
    public class AddToCartValidator : AbstractValidator<AddToCartRequest>
    {
        public AddToCartValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.IdProduct).NotEmpty().Must(state => _context.States.Any(x => x.Id == state)).WithMessage("Not valid Product.");
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
