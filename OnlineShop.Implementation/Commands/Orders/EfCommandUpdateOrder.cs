using FluentValidation;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Orders;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.Cart;
using OnlineShop.Implementation.Validators.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Orders
{
    public class EfCommandUpdateOrder : IUpdateOrderCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateOrderValidator _validator;

        public EfCommandUpdateOrder(OnlineShopContext context, UpdateOrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfCommandUpdateOrder";

        public void Execute(UpdateOrderRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findOrder = _context.Orders.Find(request.Id);
            if (findOrder == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Order));
            }

            var Order = _context.Orders.Where(x => x.Id == request.Id).FirstOrDefault();

            Order.OrderDetails = request.OrderDetails;
            Order.ShippingEstimate = request.ShippingEstimate;

            _context.SaveChanges();
        }
    }
    
}
