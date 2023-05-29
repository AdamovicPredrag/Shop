using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.User;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.User;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Users
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetUsersQuery(OnlineShopContext context)
        {
            this._context = context;
        }
        public int Id => 3;

        public string Name => "EfGetCategoryQuery";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            // throw new NotImplementedException();
            var query = _context.Users.Include(x=>x.City).ThenInclude(x=>x.State).AsQueryable();
            if ((!string.IsNullOrEmpty(search.UserName)))
            {
                query = query.Where(x => x.UserName.ToLower().Contains(search.UserName));
            }
            if ((!string.IsNullOrEmpty(search.FirstName)))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName));
            }
            if ((!string.IsNullOrEmpty(search.LastName)))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName));
            }
            if ((!string.IsNullOrEmpty(search.Address)))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 6;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page - 1) * search.PerPage;

            var response = new PagedResponse<UserDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone,
                City = new Application.DataTransfer.CityDto
                {
                    Id = user.City.Id,
                    Name = user.City.Name,
                    PostCode = user.City.PostCode,
                    StateName = user.City.State.Name
                }

            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;
        }
    }
}
