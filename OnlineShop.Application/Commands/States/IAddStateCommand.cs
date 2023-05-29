using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.States
{
    public interface IAddStateCommand:ICommand<AddStateRequest>
    {

    }
}
