using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Orders;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Cities;
using OnlineShop.Implementation.Validators.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Orders
{
    public class EfCommandAddOrder : IAddOrdersCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddOrderValidator _validator;
        private readonly IApplicationActor _actor;


        public EfCommandAddOrder(OnlineShopContext context, IApplicationActor actor, AddOrderValidator validator)
        {
            _context = context;
            _validator = validator;
            _actor = actor;

        }
        public int Id => 3;

        public string Name => "EfCommandAddOrder";

        public void Execute(AddOrderRequest request)
        {
            _validator.ValidateAndThrow(request);
            var ProductInCart = _context.CartProductUsers.Include(x => x.Product).ThenInclude(prod => prod.Shop).AsQueryable();

            ProductInCart= ProductInCart.Where(x => x.UserId == _actor.Id);


            if (ProductInCart.IsNullOrEmpty())
            {
                throw new EntityNotFoundException(request.ShopId, typeof(Domain.CartProductUser));
            }

            var ProductInCartForUpdate = _context.CartProductUsers.Where(x => x.UserId == _actor.Id).ToList();

            var OrderProducts = ProductInCart.Select(x => new OrderProducts
            {
                IdProduct = x.IdProduct,
                Quantity = x.Quantity,                
            }).ToList();



            var Order = new Order
            {
                IdUser = _actor.Id,
                OrderProducts=OrderProducts,
                OrderDetails=request.OrderDetails,
                IdShop=request.ShopId,
                ShippingEstimate="Two weeks from Order"
            };

            _context.Orders.Add(Order);

            foreach( var item in ProductInCartForUpdate)
            {
                item.IsDeleted = true;
                item.DeletedAt = DateTime.Now;
                item.IsActive = false;                 
            }

            _context.SaveChanges();


        }
    }
}
