using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.Image;
using OnlineShop.Application.DataTransfer.Order;
using OnlineShop.Application.DataTransfer.Product;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Orders;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Order
{
    public class EfGetOrdersQuery : IGetOrderQuery
    {

        public readonly OnlineShopContext _context;

        public EfGetOrdersQuery(OnlineShopContext context)
        {
            this._context = context;
        }

        public int Id => 3;

        public string Name => "EfGetCityQuery";

        public PagedResponse<OrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders
                .Include(x => x.OrderProducts).ThenInclude(x => x.Product).ThenInclude(x=>x.Category)
                .Include(x => x.OrderProducts).ThenInclude(x => x.Product).ThenInclude(x=>x.Images)
                .Include(x => x.User)
                .Include(x => x.Shop)
                .AsQueryable();


            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 6;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page - 1) * search.PerPage;

            var response = new PagedResponse<OrderDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new OrderDto
            {
                Id = x.Id,
                OrderDetails = x.OrderDetails,
                ShippingEstimate = x.ShippingEstimate,
                User = new Application.DataTransfer.User.UserOrderDto
                {
                    Id = x.User.Id,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    Phone = x.User.Phone
                },
                Shop = new Application.DataTransfer.Shop.ShopOrderDto
                {
                    Id = x.Shop.Id,
                    Name = x.Shop.Name,
                    Address = x.Shop.Address,
                    Description = x.Shop.Description,
                    Phone = x.Shop.Phone,
                    Email = x.Shop.Email,
                },

                Products = (ICollection<ProductDto>)x.OrderProducts.Select(x=> new ProductDto
                {
                    Id=x.Product.Id,
                    Name=x.Product.Name,
                    Description=x.Product.Description,
                    ShopName=x.Product.Shop.Name,
                    Size=x.Product.Size,
                    Images = (ICollection<ImageDto>)x.Product.Images.Select(x => new ImageDto
                    {
                        Id = x.Id,
                        Path = x.Path
                    }),
                    Category =new CategoriesDto
                    {
                        Id=x.Product.Category.Id,
                        Name= x.Product.Category.Name
                    }                   
                })

            }).ToList();

            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;
        }
    }
}
