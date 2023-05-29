using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Requests.States
{
    public class UpdateStateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
