using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Cart
{
    public class DeleteCartValidator : AbstractValidator<int>
    {
        public DeleteCartValidator()
        {
            RuleFor(x => x).NotEmpty().GreaterThan(0);
        }
    }
}
