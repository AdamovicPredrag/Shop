using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DataTransfer;
using OnlineShop.Application.DataTransfer.WorkingHours;
using OnlineShop.Application.Queries;
using OnlineShop.Application.Queries.WorkingHours;
using OnlineShop.Application.Searches;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Queries.WorkingHours
{
    public class EfGetWorkingHoursQuery : IGetWorkingHoursQuery
    {
        public readonly OnlineShopContext _context;

        public EfGetWorkingHoursQuery(OnlineShopContext context)
        {
            this._context = context;
        }
        public int Id => 3;

        public string Name => "EfGetWorkingHoursQuery";

        public PagedResponse<WorkingHoursDto> Execute(WorkingHoursSearch search)
        {
            var query = _context.WorkingHours.Include(x=>x.Shop).AsQueryable();



            if ((!string.IsNullOrEmpty(search.MondayFromTo)))
            {
                query = query.Where(x => x.MondayFromTo.ToLower().Contains(search.MondayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.TuesdayFromTo)))
            {
                query = query.Where(x => x.TuesdayFromTo.ToLower().Contains(search.TuesdayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.WednesdayFromTo)))
            {
                query = query.Where(x => x.WednesdayFromTo.ToLower().Contains(search.WednesdayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.ThursdayFromTo)))
            {
                query = query.Where(x => x.ThursdayFromTo.ToLower().Contains(search.ThursdayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.FridayFromTo)))
            {
                query = query.Where(x => x.FridayFromTo.ToLower().Contains(search.FridayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.SaturdayFromTo)))
            {
                query = query.Where(x => x.SaturdayFromTo.ToLower().Contains(search.SaturdayFromTo));
            }
            if ((!string.IsNullOrEmpty(search.SundayFromTo)))
            {
                query = query.Where(x => x.SundayFromTo.ToLower().Contains(search.SundayFromTo));
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

            var response = new PagedResponse<WorkingHoursDto>();
            response.TotalCount = query.Count();
            response.Items = query.Skip(toSkip).Take(search.PerPage).Select(x => new WorkingHoursDto
            {
                Id = x.Id,
                MondayFromTo=x.MondayFromTo,
                TuesdayFromTo = x.TuesdayFromTo,
                WednesdayFromTo = x.WednesdayFromTo,
                ThursdayFromTo = x.ThursdayFromTo,
                FridayFromTo = x.FridayFromTo,
                SaturdayFromTo = x.SaturdayFromTo,
                SundayFromTo = x.SundayFromTo,
                ShopName=x.Shop.Name,
                IdShop=x.Shop.Id
               
            }).ToList();
            response.CurrentPage = search.Page;
            response.ItemsPerPage = search.PerPage;

            return response;
        }
    }
}
