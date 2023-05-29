using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Categories;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Category
{
    public class EfGetCategoriesQuery : IGetCategoryQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetCategoriesQuery(OnlineShopContext context)
        {
            this._context = context;
        }
        public int Id => 3;

        public string Name => "EfGetCategoryQuery";

        public PagedResponse<CategoriesDto> Execute(CategorySearch search)
        {
            // throw new NotImplementedException();
            var query = _context.Categories.AsQueryable();
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

            var response = new PagedResponse<CategoriesDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new CategoriesDto
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
