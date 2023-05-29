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
    public class UpdateCityValidator:AbstractValidator<UpdateCityRequest>
    {
        public UpdateCityValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must((request, n) => !_context.Cities.Any(x => x.Name == request.Name && x.Id != request.Id))
                .WithMessage("City must be unique.");
            RuleFor(x => x.StateId).NotEmpty().NotEmpty().Must(state => _context.States.Any(x => x.Id == state)).WithMessage("Not valid State.");
        }
    }
}
