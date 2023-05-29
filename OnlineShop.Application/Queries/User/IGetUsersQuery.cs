using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer.Cart;
using OnlineShop.Application.DataTransfer.User;
using OnlineShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Queries.User
{
    public interface IGetUsersQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {

    }
}
