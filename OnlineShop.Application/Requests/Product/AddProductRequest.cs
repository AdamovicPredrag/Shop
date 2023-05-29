using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Product
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string? ImageFileName { get; set; }
        public int CategoryId { get; set; }
        public int IdShop { get; set; }
    }
}
