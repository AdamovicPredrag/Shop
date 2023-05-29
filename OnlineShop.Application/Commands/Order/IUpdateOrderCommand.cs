using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Order
{
    public interface IUpdateOrderCommand : ICommand<UpdateOrderRequest>
    {

    }
}
