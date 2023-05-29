using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class ExceptionLog:Entity
    {
        public string Response { get; set; }
        public int StatusCode { get; set; }
        public string Exception { get; set; }
    }
}
