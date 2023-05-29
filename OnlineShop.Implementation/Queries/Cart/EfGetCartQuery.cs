using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Base;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.Cart;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Cart;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Cart
{
    public class EfGetCartQuery : IGetCartQuery
    {
        public readonly OnlineShopContext _context;
        private readonly IApplicationActor _actor;


        public EfGetCartQuery(OnlineShopContext context,  IApplicationActor actor)
        {
            this._context = context;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "EfGetCityQuery";

        public PagedResponse<CartDto> Execute(CartSearch search)
        {
            var query = _context.CartProductUsers.Include(x => x.Product).ThenInclude(prod=>prod.Shop).AsQueryable();

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 6;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            query = query.Where(x => x.UserId == _actor.Id);

            var toSkip = (search.Page - 1) * search.PerPage;

            var response = new PagedResponse<CartDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new CartDto
            {
                Id = x.Id,
                IdProduct=x.IdProduct,
                UserId=x.UserId,
                ProductName=x.Product.Name,
                ProductDescripton=x.Product.Description,
                ShopName=x.Product.Shop.Name

            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;

        }
    }
}
