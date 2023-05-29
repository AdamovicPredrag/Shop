using FluentValidation;
using OnlineShop.Application.Commands.Cart;
using OnlineShop.Application.Exceptions;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.Cart;
using OnlineShop.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Cart
{
    public class EfCommandDeleteCart : IDeleteCartCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteCartValidator _validator;

        public EfCommandDeleteCart(OnlineShopContext context, DeleteCartValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfDeleteCartCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findCart = _context.CartProductUsers.Find(request);
            if (findCart == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.CartProductUser));
            }

            findCart.IsDeleted = true;
            findCart.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
