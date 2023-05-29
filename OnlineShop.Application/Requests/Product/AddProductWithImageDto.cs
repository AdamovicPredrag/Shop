using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Product
{
    public class AddProductWithImageDto :AddProductRequest
    {
        public IFormFile Image { get; set; }

    }
}
