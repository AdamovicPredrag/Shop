using FluentValidation;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Shop
{
    public class UpdateShopValidator : AbstractValidator<UpdateShopRequest>
    {
        public UpdateShopValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).Matches("[A-z0-9]*").WithMessage("Shop name must contains letters and numbers");
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
}
}
