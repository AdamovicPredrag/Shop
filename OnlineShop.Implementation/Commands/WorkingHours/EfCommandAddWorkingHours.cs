using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.WorkingHours;
using OnlineShop.Application.Requests.WorkingHours;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Cities;
using OnlineShop.Implementation.Validators.WorkingHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.WorkingHours
{
    public class EfCommandAddWorkingHours : IAddWorkingHoursCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddWorkingHoursValidator _validator;

        public EfCommandAddWorkingHours(OnlineShopContext context, AddWorkingHoursValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "EfCommandAddWorkingHours";

        public void Execute(AddWorkingHoursRequest request)
        {
            _validator.ValidateAndThrow(request);
            var WorkingHours = new Domain.WorkingHours
            {
                MondayFromTo=request.MondayFromTo,
                TuesdayFromTo = request.TuesdayFromTo,
                WednesdayFromTo = request.WednesdayFromTo,
                ThursdayFromTo = request.ThursdayFromTo,
                FridayFromTo = request.FridayFromTo,
                SaturdayFromTo = request.SaturdayFromTo,
                SundayFromTo = request.SundayFromTo,
                IdShop=request.IdShop

            };
            _context.WorkingHours.Add(WorkingHours);
            _context.SaveChanges();
        }
    }
}
