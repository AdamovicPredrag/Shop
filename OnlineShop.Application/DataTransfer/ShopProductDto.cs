using OnlineShop.Application.DataTransfer.Image;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer
{
    public class ShopProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public ICollection<ImageDto> Images { get; set; } = new HashSet<ImageDto>();
        public CategoriesDto Category { get; set; }
    }
}
