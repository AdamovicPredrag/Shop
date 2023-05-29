using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescripton { get; set; }
        public string ShopName { get; set; }
    }
}
