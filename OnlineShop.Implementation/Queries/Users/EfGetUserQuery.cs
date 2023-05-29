using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer.User;
using OnlineShop.Application.Queries.User;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Users
{
    public class EfGetUserQuery : IGetUserQuery
    {
        public readonly OnlineShopContext _context;
        private readonly IApplicationActor _actor;


        public EfGetUserQuery(OnlineShopContext context, IApplicationActor actor)
        {
            this._context = context;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "EfGetCurrentUserQuery";


        public UserDto Execute(UserDto search)
        {
            var query = _context.Users.Include(x => x.City).ThenInclude(city => city.State);
            var user = query.Where(x => x.Id == _actor.Id).FirstOrDefault();

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone,
                City=new Application.DataTransfer.CityDto
                {
                    Id=user.City.Id,
                    Name=user.City.Name,
                    PostCode=user.City.PostCode,
                    StateName=user.City.State.Name        
                }
            };
        }
    }
}
