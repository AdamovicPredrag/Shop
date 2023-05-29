using OnlineShop.Application.DataTransfer.Product;
using OnlineShop.Application.DataTransfer.Shop;
using OnlineShop.Application.DataTransfer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderDetails { get; set; }
        public string ShippingEstimate { get; set; }
        public UserOrderDto User { get; set; }
        public ShopOrderDto Shop { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
