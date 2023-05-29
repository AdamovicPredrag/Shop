using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.Categories
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
