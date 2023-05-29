using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Queries.Shops
{
    public interface IGetShopsQuery : IQuery<ShopSearch, PagedResponse<ShopDto>>
    {
    }
}
