using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.State
{
    public class DeleteStateValidator : AbstractValidator<int>
    {
        public DeleteStateValidator()
        {
            RuleFor(x => x).NotEmpty();

        }
    }
}
