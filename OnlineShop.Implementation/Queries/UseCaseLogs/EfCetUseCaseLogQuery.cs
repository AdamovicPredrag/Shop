using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.UseCaseLog;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.UseCaseLogs
{
    public class EfCetUseCaseLogQuery : IGetUseCaseLogQuery
    {
        public readonly OnlineShopContext _context;

        public EfCetUseCaseLogQuery(OnlineShopContext context)
        {
            this._context = context;
        }

        public int Id => 7;

        public string Name => "EfGetUseCaseLogsQuery";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (search.DateFrom != DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedAt.Date >= search.DateFrom.Date);
            }

            if (search.DateTo != DateTime.MinValue && search.DateTo >= search.DateFrom)
            {
                query = query.Where(x => x.CreatedAt.Date <= search.DateTo.Date);
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

            var response =  new PagedResponse<UseCaseLogDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new UseCaseLogDto
            {
                Id = x.Id,
                Actor = x.Actor,
                Data = x.Data,
                UseCaseName = x.UseCaseName,
                CreatedAt = x.CreatedAt

            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;
        }
    }
}
