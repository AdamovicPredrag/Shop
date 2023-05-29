using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Categories;
using OnlineShop.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Shop
{
    public class EfCommandUpdateShop : IUpdateShopCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateShopValidator _validator;

        public EfCommandUpdateShop(OnlineShopContext context, UpdateShopValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "EfCommandUpdateShop";

        public void Execute(UpdateShopRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findShop = _context.Shops.Find(request.Id);
            if (findShop == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Shop));
            }

            var Shops = _context.Shops.Where(x => x.Id == request.Id).FirstOrDefault();

            Shops.Name = request.Name;
            Shops.Description = request.Description;
            Shops.Phone = request.Phone;
            Shops.Address = request.Address;
            Shops.Email = request.Email;
            Shops.CityId = request.CityId;
            _context.SaveChanges();

        }
    }
}
