using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DataTransfer
{
    public class UseCaseLogDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UseCaseName { get; set; }
        public string Actor { get; set; }
        public string Data { get; set; }
    }
}
