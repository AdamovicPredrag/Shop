using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Cart
{
    public class AddToCartRequest
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

    }
}
