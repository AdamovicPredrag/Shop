using OnlineShop.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.Application.Commands.Categories
{
    public interface IDeleteCategoryCommand:ICommand<int>
    {
    }
}
