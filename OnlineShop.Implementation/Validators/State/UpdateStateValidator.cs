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
    public class UpdateStateValidator:AbstractValidator<UpdateStateRequest>
    {
        public UpdateStateValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must((request, n) => !_context.States.Any(x => x.Name == request.Name && x.Id != request.Id));
        }
    }
}
