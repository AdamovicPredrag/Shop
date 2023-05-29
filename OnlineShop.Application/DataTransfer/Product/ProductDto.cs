using OnlineShop.Application.DataTransfer.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ShopName { get; set; }
        public ICollection<ImageDto> Images { get; set; } = new HashSet<ImageDto>();
        public int ShopId { get; set; }
        public CategoriesDto Category { get; set; }
    }
}
