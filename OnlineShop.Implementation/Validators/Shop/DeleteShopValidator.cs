using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Shop
{
    public class DeleteShopValidator : AbstractValidator<int>
    {
        public DeleteShopValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
