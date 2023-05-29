using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Cities
{
    public class AddCityRequest
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public int StateId { get; set; }
    }
}
