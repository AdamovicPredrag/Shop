using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Cities
{
    public class DeleteCityValidator : AbstractValidator<int>
    {
        public DeleteCityValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
