using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Queries.User
{
    public interface IGetUserQuery : IQuery<UserDto, UserDto>
    {

    }
}
