﻿using OnlineShop.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Commands.Order
{
    public interface IDeleteOrderCommand : ICommand<int>
    {
    }

}
