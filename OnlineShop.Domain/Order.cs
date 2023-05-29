using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Order:Entity
    {
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdShop { get; set; }
        public Shop Shop { get; set; }
        public string OrderDetails { get; set; }
        public string ShippingEstimate { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }= new HashSet<OrderProducts>();

    }
}
