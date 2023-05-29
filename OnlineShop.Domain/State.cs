using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class State:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<City> City { get; set; }=new HashSet<City>();
    }
}
