using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.WorkingHours
{
    public class DeleteWorkingHoursValidator : AbstractValidator<int>
    {
        public DeleteWorkingHoursValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
