using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class OrderProducts:Entity
    {
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
