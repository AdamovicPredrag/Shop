using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Shop
{
    public class AddShopValidator : AbstractValidator<AddShopRequest>
    {
        public AddShopValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).Matches("[A-z0-9]*").WithMessage("Shop name must contains numbers and letters");
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CityId).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty().Must(phone => !_context.Shops.Any(x => x.Phone == phone)).WithMessage("Phone is taken."); ;
            RuleFor(x => x.Email).EmailAddress().Must(email => !_context.Shops.Any(x => x.Email == email)).WithMessage("Email is taken."); ;
        }
    }
}
