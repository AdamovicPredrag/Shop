using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Users
{
    public interface IUpdateCurrentUserCommand : ICommand<UpdateCurrentUserRequest>
    {

    }

}
