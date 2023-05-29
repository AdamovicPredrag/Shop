using OnlineShop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Searches
{
    public class CitySearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
