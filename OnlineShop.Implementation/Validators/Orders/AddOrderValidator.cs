﻿using FluentValidation;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Orders;
using OnlineShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Validators.Orders
{
    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator(OnlineShopContext _context)
        {
            RuleFor(x => x.OrderDetails).NotEmpty();
        }
    }
}
