using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Exceptions;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Categories;
using OnlineShop.Implementation.Validators.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Cities
{
    public class EfCommandDeleteCity : IDeleteCityCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteCityValidator _validator;

        public EfCommandDeleteCity(OnlineShopContext context, DeleteCityValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfDeleteCityCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findCity = _context.Cities.Find(request);
            if (findCity == null)
            {
                throw new EntityNotFoundException(request, typeof(City));
            }

            findCity.IsDeleted = true;
            findCity.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
