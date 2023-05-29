using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.WorkingHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.WorkingHours
{
    public interface IUpdateWorkingHoursCommand:ICommand<UpdateWorkingHoursRequest>
    {
    }
}
