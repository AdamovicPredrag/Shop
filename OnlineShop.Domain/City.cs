using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class City:Entity
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public virtual ICollection<User> Users { get; set; }=new HashSet<User>();
        public virtual ICollection<Shop> Shops { get; set; }=new HashSet<Shop>();
    }
}
