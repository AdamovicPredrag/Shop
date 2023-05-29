using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Cities
{
    public class EfGetCityQuery : IGetCityQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetCityQuery(OnlineShopContext context)
        {
            this._context = context;
        }

        public int Id => 3;

        public string Name => "EfGetCityQuery";

        public PagedResponse<CityDto> Execute(CitySearch search)
        {
            // throw new NotImplementedException();
            var query = _context.Cities.Include(x => x.State).AsQueryable();
            if ((!string.IsNullOrEmpty(search.Name)))
            {
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

            var response = new PagedResponse<CityDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new CityDto
            {
                Id = x.Id,
                Name = x.Name,
                PostCode=x.PostCode,
                StateName= x.State.Name
                
            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;
        }
    }
}
