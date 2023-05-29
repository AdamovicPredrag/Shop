using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Shop
{
    public interface IUpdateShopCommand: ICommand<UpdateShopRequest>
    {
    }
}
