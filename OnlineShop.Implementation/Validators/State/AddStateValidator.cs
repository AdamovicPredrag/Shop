using FluentValidation;
using OnlineShop.Application.Requests.States;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.State
{
    public class AddStateValidator:AbstractValidator<AddStateRequest>
    {
        public AddStateValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(x => !_context.States.Any(c => c.Name == x)).WithMessage("State name must be unique!");
        }
    }
}
