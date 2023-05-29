using OnlineShop.Application.Base;
using OnlineShop.Application.Requests.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Categories
{
    public interface IAddCategoryCommand:ICommand<AddCategoryRequest>
    {

    }
}
