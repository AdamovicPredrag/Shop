using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Cities
{
    public interface IAddCityCommand:ICommand<AddCityRequest>
    {
    }
}
