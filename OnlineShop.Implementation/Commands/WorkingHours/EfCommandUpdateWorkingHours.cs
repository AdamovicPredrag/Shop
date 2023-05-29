using FluentValidation;
using OnlineShop.Application.Commands.WorkingHours;
using OnlineShop.Application.Exceptions;
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
    public class EfCommandUpdateWorkingHours : IUpdateWorkingHoursCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateWorkingHoursValidator _validator;

        public EfCommandUpdateWorkingHours(OnlineShopContext context, UpdateWorkingHoursValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfCommandUpdateWorking";

        public void Execute(UpdateWorkingHoursRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findWorkingHours = _context.WorkingHours.Find(request.Id);
            if (findWorkingHours == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.WorkingHours));
            }

            var WorkingHours = _context.WorkingHours.Where(x => x.Id == request.Id).FirstOrDefault();
            
            WorkingHours.MondayFromTo = request.MondayFromTo;
            WorkingHours.TuesdayFromTo = request.TuesdayFromTo;
            WorkingHours.WednesdayFromTo = request.WednesdayFromTo;
            WorkingHours.ThursdayFromTo = request.ThursdayFromTo;
            WorkingHours.FridayFromTo = request.FridayFromTo;
            WorkingHours.SaturdayFromTo = request.SaturdayFromTo;
            WorkingHours.SundayFromTo = request.SundayFromTo;
            WorkingHours.IdShop = request.IdShop;

            _context.SaveChanges();
        }
    }
}
