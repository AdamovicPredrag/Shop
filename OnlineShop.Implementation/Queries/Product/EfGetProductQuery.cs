using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.Image;
using OnlineShop.Application.DataTransfer.Product;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Products;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Product
{
    public class EfGetProductQuery : IGetProductQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetProductQuery(OnlineShopContext context)
        {
            this._context = context;
        }
        public int Id => 3;

        public string Name => "EfGetProductQuery";

        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Include(x=>x.Images)
                .Include(x=>x.Shop).AsQueryable();

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

            var response = new PagedResponse<ProductDto>();
            response.TotalCount = query.Count();

            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new ProductDto
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description,
                Size=x.Size,
                Images= (ICollection<ImageDto>)x.Images.Select(x => new ImageDto
                {
                    Id = x.Id,
                    Path = x.Path
                }),
                Category =new CategoriesDto
                {
                    Id=x.Category.Id,
                    Name= x.Category.Name,
                    
                },
                ShopId=x.Shop.Id,
                ShopName=x.Shop.Name

            }).ToList();

            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;

        }

    }
}
