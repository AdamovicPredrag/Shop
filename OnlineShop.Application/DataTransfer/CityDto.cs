using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string StateName { get; set; }
    }
}
