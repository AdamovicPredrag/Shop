using FluentValidation;
using OnlineShop.Application.Commands.Cart;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Cart;
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
    public class EfCommandUpdateCart : IUpdateCartCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateCartValidator _validator;

        public EfCommandUpdateCart(OnlineShopContext context, UpdateCartValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfCommandUpdateCart";

        public void Execute(UpdateCartRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findCart = _context.CartProductUsers.Find(request.Id);
            if (findCart == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.CartProductUser));
            }

            var Cart = _context.CartProductUsers.Where(x => x.Id == request.Id).FirstOrDefault();

            Cart.Quantity = request.Quantity;

            _context.SaveChanges();
        }
    }
}
