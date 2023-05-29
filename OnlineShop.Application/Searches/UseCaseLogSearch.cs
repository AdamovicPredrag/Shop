using OnlineShop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Searches
{
    public class UseCaseLogSearch:PagedSearch
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
    }
}
