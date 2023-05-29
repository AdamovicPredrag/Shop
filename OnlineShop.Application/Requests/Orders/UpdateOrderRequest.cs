using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Orders
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        public string OrderDetails { get; set; }
        public string ShippingEstimate { get; set; }

    }
}
