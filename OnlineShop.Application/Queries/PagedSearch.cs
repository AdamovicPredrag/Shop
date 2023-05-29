using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Queries
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 6;
        public int Page { get; set; } = 1;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; } = DateTime.UtcNow;
    }
}
