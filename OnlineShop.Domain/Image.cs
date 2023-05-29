using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Image:Entity
    {
        public string Path { get; set; }
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }
    }
}
