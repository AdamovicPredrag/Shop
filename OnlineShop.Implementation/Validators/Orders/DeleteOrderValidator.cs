using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Orders
{
    public class DeleteOrderValidator : AbstractValidator<int>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}