using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Shop:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }    
        public virtual City City { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public virtual ICollection<Product> Products { get; set; }=new HashSet<Product>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
