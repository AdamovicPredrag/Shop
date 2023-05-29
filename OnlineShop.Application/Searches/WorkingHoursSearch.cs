using OnlineShop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Searches
{
    public class WorkingHoursSearch : PagedSearch
    {
        public string MondayFromTo { get; set; } = "";
        public string TuesdayFromTo { get; set; } = "";
        public string WednesdayFromTo { get; set; } = "";
        public string ThursdayFromTo { get; set; } = "";
        public string FridayFromTo { get; set; } = "";
        public string SaturdayFromTo { get; set; } = "";
        public string SundayFromTo { get; set; } = "";
    }
}
