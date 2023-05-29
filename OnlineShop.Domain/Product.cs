using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int IdShop { get; set; }
        public virtual Shop Shop { get; set; }
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProducts> ProductOrders { get; set; } = new HashSet<OrderProducts>();
        public virtual ICollection<CartProductUser> CartProductUsers { get; set; } = new HashSet<CartProductUser>();
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

    }
}
