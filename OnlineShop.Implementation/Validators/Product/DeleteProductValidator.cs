using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<int>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
