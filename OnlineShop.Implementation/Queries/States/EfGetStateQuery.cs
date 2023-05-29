using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.States
{
    public class EfGetStateQuery : IGetStatesQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetStateQuery (OnlineShopContext context)
        {
            this._context = context;
        }
        public int Id =>3;

        public string Name => "EfGetStatesQuery";

        public PagedResponse<StatesDto> Execute(StateSearch search)
        {
            // throw new NotImplementedException();
            var query = _context.States.AsQueryable();
            if ((!string.IsNullOrEmpty(search.Name))){
                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
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

            var response = new PagedResponse<StatesDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new StatesDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;

        }
    }
}
