using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.Product;
using OnlineShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Queries.Products
{
    public interface IGetProductQuery : IQuery<ProductSearch, PagedResponse<ProductDto>>
    {

    }
}
