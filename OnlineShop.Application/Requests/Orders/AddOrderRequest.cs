using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Orders
{
    public class AddOrderRequest
    {
        public string OrderDetails { get; set; }
        public int ShopId { get; set; }
    }
}
