using AutoMapper;
using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.States;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Commands.Categories;
using OnlineShop.Implementation.Validators.Categories;
using OnlineShop.Implementation.Validators.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.States
{
    public class EfCommandAddState : IAddStateCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddStateValidator _validator;
        public EfCommandAddState(OnlineShopContext context, AddStateValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfAddStateCommand";

        public void Execute(AddStateRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var State = new State
            {
                Name = reqeust.Name
            };
            _context.States.Add(State);

            _context.SaveChanges();
        }
    }
}
