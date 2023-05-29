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
    public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
    {
        public UpdateCartValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
