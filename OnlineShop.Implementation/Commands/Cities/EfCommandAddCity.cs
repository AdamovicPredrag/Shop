using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Cities;
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
    public class EfCommandAddCity:IAddCityCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddCityValidator _validator;

        public EfCommandAddCity(OnlineShopContext context, AddCityValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfCommandAddCity";

        public void Execute(AddCityRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);
            var City = new City
            {
                Name = reqeust.Name,
                PostCode=reqeust.PostCode,
                StateId=reqeust.StateId

            };
            _context.Cities.Add(City);
            _context.SaveChanges();
        }
    }
}
