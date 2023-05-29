using FluentValidation;
using OnlineShop.Application.Commands.WorkingHours;
using OnlineShop.Application.Exceptions;
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
    public class EfCommandDeleteWorkingHours : IDeleteWorkingHoursCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteWorkingHoursValidator _validator;

        public EfCommandDeleteWorkingHours(OnlineShopContext context, DeleteWorkingHoursValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfDeleteWorkingHoursCommand";
        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findWorkingHours = _context.WorkingHours.Find(request);
            if (findWorkingHours == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.WorkingHours));
            }

            findWorkingHours.IsDeleted = true;
            findWorkingHours.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
