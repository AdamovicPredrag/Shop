using FluentValidation;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Users;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Users;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Users
{
    public class EfCommandUpdateCurrentUser : IUpdateCurrentUserCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateCurrentUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCommandUpdateCurrentUser(OnlineShopContext context, IApplicationActor actor, UpdateCurrentUserValidator validator)
        {
            _context = context;
            _validator = validator;
            _actor = actor;

        }
        public int Id => 3;
        public string Name => "EfCommandUpdateUser";

        public void Execute(UpdateCurrentUserRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findProduct = _context.Users.Find(_actor.Id);
            if (findProduct == null)
            {
                throw new EntityNotFoundException(_actor.Id, typeof(Domain.User));
            }

            var User = _context.Users.Where(x => x.Id == _actor.Id).FirstOrDefault();
            User.FirstName = request.FirstName;
            User.LastName = request.LastName;
            User.UserName = request.UserName;
            User.Phone = request.Phone;
            User.Email = request.Email;
            User.Password = request.Password;
            User.Address = request.Address;

            _context.SaveChanges();
        }
    }
}
