using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CityDto City { get; set; }
        public ShopWorkingHoursDto WorkingHours { get; set; }
        public ICollection<ShopProductDto> Products { get; set; }
    }
}
