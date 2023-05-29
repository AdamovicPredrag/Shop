using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.Cities;
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
    public class EfCommandUpdateCity : IUpdateCityCommand
    {

        private readonly OnlineShopContext _context;
        private readonly UpdateCityValidator _validator;

        public EfCommandUpdateCity(OnlineShopContext context, UpdateCityValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfCommandUpdateCity";

        public void Execute(AddCityRequest request)
        {
            throw new NotImplementedException();
        }

        public void Execute(UpdateCityRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findCity = _context.Cities.Find(request.Id);
            if (findCity == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(City));
            }

            var city = _context.Cities.Where(x => x.Id == request.Id).FirstOrDefault();
            city.Name = request.Name;
            city.PostCode = request.PostCode;
            city.StateId = request.StateId;
            _context.SaveChanges();
        }
    }
}
