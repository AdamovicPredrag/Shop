using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Product
{
    public interface IUpdateProductCommand : ICommand<UpdateProductRequest>
    {

    }
}
