using FluentValidation;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Cities
{
    public class AddCityValidator : AbstractValidator<AddCityRequest>
    {
        public AddCityValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must(x => !_context.Cities.Any(c => c.Name == x)).WithMessage("City name must be unique!");
            RuleFor(x => x.PostCode).NotEmpty().MinimumLength(2).Must(x => !_context.Cities.Any(c => c.PostCode == x)).WithMessage("Post Code must be unique!");
            RuleFor(x => x.StateId).NotEmpty().NotEmpty().Must(state => _context.States.Any(x => x.Id == state)).WithMessage("Not valid State.");
        }
    }
}
