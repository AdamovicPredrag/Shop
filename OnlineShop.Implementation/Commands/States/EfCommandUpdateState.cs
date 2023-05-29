using AutoMapper;
using FluentValidation;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.States;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.States
{
    public class EfCommandUpdateState:IUpdateStateCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateStateValidator _validator;

        public EfCommandUpdateState(OnlineShopContext context, UpdateStateValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfUpdateStateCommand";

        public void Execute(UpdateStateRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findState = _context.States.Find(request.Id);
            if (findState == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(City));
            }

            var States = _context.States.Where(x => x.Id == request.Id).FirstOrDefault();

            States.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
