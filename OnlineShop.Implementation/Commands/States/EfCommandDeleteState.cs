using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Exceptions;
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
    public class EfCommandDeleteState : IDeleteStateCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteStateValidator _validator;

        public EfCommandDeleteState(OnlineShopContext context, DeleteStateValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id =>6;

        public string Name => "EfDeleteStateCommand";

        public void Execute(int reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var findState = _context.States.Find(reqeust);
            if (findState == null)
            {
                throw new EntityNotFoundException(reqeust, typeof(State));
            }

            findState.IsDeleted = true;
            findState.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
