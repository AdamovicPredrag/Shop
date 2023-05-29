using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class WorkingHours:Entity
    {
        public string MondayFromTo { get; set; }
        public string TuesdayFromTo { get; set; }
        public string WednesdayFromTo { get; set; }
        public string ThursdayFromTo { get; set; }
        public string FridayFromTo { get; set; }
        public string SaturdayFromTo { get; set; }
        public string SundayFromTo { get; set; }
        public int IdShop { get; set; }
        public Shop Shop { get; set; }
    }
}
