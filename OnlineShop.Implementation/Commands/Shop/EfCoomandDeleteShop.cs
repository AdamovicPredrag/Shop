using FluentValidation;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Exceptions;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Cities;
using OnlineShop.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Shop
{
    public class EfCoomandDeleteShop : IDeleteShopCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteShopValidator _validator;

        public EfCoomandDeleteShop(OnlineShopContext context, DeleteShopValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "EfDeleteShopCommand";


        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findShop = _context.Shops.Find(request);
            if (findShop == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Shop));
            }

            findShop.IsDeleted = true;
            findShop.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
