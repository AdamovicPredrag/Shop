using FluentValidation;
using OnlineShop.Application.Requests.Product;
using OnlineShop.Application.Requests.WorkingHours;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.WorkingHours
{
    public class AddWorkingHoursValidator : AbstractValidator<AddWorkingHoursRequest>
    {
        public AddWorkingHoursValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.MondayFromTo).NotEmpty();
            RuleFor(x => x.ThursdayFromTo).NotEmpty();
            RuleFor(x => x.WednesdayFromTo).NotEmpty();
            RuleFor(x => x.ThursdayFromTo).NotEmpty();
            RuleFor(x => x.FridayFromTo).NotEmpty();
            RuleFor(x => x.SaturdayFromTo).NotEmpty();
            RuleFor(x => x.SundayFromTo).NotEmpty();
            RuleFor(x => x.IdShop).NotEmpty().NotEmpty().Must(cat => _context.Shops.Any(x => x.Id == cat)).WithMessage("Shop is not valid.");
        }
    }
}
