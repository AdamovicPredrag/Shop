using FluentValidation;
using OnlineShop.Application.Requests.Authorisaation;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Authorisation
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).WithMessage("First name must have minimum 2 characters");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).WithMessage("Last name must have minimum 2 characters");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(2).WithMessage("User name must have minimum 2 characters");
            RuleFor(x => x.Address).NotEmpty().MinimumLength(2).WithMessage("Address must have minimum 2 characters");
            RuleFor(x => x.CityId).NotEmpty().Must(city => _context.Cities.Any(x => x.Id == city)).WithMessage("Not valid City.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(email => !_context.Users.Any(x => x.Email == email)).WithMessage("Email is taken.");
            RuleFor(x => x.Phone).NotEmpty().Must(phone => !_context.Users.Any(x => x.Phone == phone)).WithMessage("Phone is taken.");
        }
    }
}
