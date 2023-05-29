using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Cart;
using OnlineShop.Application.Requests.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Cart
{
    public interface IAddToCartCommand : ICommand<AddToCartRequest>
    {

    }
}
