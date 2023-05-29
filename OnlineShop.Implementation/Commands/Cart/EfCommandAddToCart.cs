using FluentValidation;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cart;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Cart;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.Cart;
using OnlineShop.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Cart
{
    public class EfCommandAddToCart : IAddToCartCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddToCartValidator _validator;
        private readonly IApplicationActor _actor;


        public EfCommandAddToCart(OnlineShopContext context, IApplicationActor actor, AddToCartValidator validator)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "EfCommandAddToCart";

        public void Execute(AddToCartRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findCart = _context.CartProductUsers.Where(x => x.IdProduct == request.IdProduct && x.UserId== _actor.Id && x.IsDeleted==false).FirstOrDefault();
            if (findCart == null)
            {
                var Cart = new OnlineShop.Domain.CartProductUser
                {
                    UserId = _actor.Id,
                    IdProduct = request.IdProduct,
                    Quantity = request.Quantity,
                };
                _context.CartProductUsers.Add(Cart);
                _context.SaveChanges();
            }
            else
            {
                var Cart = _context.CartProductUsers.Where(x => x.IdProduct == request.IdProduct && x.UserId == _actor.Id).FirstOrDefault();

                Cart.Quantity = request.Quantity;

                _context.SaveChanges();
            }

        }
    }
}
