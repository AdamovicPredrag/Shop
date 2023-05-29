using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.Image;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.Shops;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.Shops
{
    public class EfGetShopsQuery : IGetShopsQuery
    {

        public readonly OnlineShopContext _context;

        public EfGetShopsQuery(OnlineShopContext context)
        {
            this._context = context;
        }

        public int Id => 3;

        public string Name => "EfGetShopsQuery";

        public PagedResponse<ShopDto> Execute(ShopSearch search)
        {
            //throw new NotImplementedException();

            // throw new NotImplementedException();
            var query = _context.Shops
                .Include(x=>x.WorkingHours)
                .Include(x=>x.City).ThenInclude(x => x.State)
                .Include(x => x.Products).ThenInclude(x=>x.Category)
                .Include(x=>x.Products).ThenInclude(x=>x.Images)
                .AsQueryable();
            
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

            var response = new PagedResponse<ShopDto>();
            response.TotalCount = query.Count();

            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new ShopDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Products = (ICollection<ShopProductDto>)x.Products.Select(prod => new ShopProductDto
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Description = prod.Description,
                    Category = new CategoriesDto
                    {
                        Id=prod.Category.Id,
                        Name=prod.Category.Name
                    },
                    Images = (ICollection<ImageDto>)prod.Images.Select(x => new ImageDto
                    {
                        Id = x.Id,
                        Path = x.Path
                    }),
                }),
                Phone=x.Phone,
                Email=x.Email,
                Address=x.Address,
                City=new CityDto
                {
                    Id=x.City.Id,
                    Name=x.City.Name,
                    PostCode=x.City.PostCode,
                    StateName =x.City.State.Name
                },
                WorkingHours=new ShopWorkingHoursDto
                {
                    MondayFromTo=x.WorkingHours.MondayFromTo,
                    TuesdayFromTo = x.WorkingHours.TuesdayFromTo,
                    WednesdayFromTo = x.WorkingHours.WednesdayFromTo,
                    ThursdayFromTo = x.WorkingHours.ThursdayFromTo,
                    FridayFromTo = x.WorkingHours.FridayFromTo,
                    SaturdayFromTo = x.WorkingHours.SaturdayFromTo,
                    SundayFromTo = x.WorkingHours.SundayFromTo,
                }



            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;

        }
    }
}
