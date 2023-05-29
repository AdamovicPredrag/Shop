using FluentValidation;
using OnlineShop.Application.Requests.User;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Authorisation
{
    public class LoginUserValidator : AbstractValidator<LoginRequest>
    {
        public LoginUserValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty")
                .Must(x => _context.Users.Any(user => user.Email == x)).WithMessage("User doesn't exist!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Email must not be empty").Must(x => _context.Users.Any(user => user.UserName == x)).WithMessage("User doesn't exist!");
        }
    }

}
