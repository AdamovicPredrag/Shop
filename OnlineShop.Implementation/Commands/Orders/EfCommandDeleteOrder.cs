using FluentValidation;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Exceptions;
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
    public class EfCommandDeleteOrder : IDeleteOrderCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteOrderValidator _validator;

        public EfCommandDeleteOrder(OnlineShopContext context, DeleteOrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfDeleteOrderCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findOrder = _context.Orders.Find(request);
            if (findOrder == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Order));
            }

            findOrder.IsDeleted = true;
            findOrder.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
