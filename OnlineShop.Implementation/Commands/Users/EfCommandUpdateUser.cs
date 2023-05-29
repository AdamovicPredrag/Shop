using FluentValidation;
using OnlineShop.Application.Commands.Users;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Users;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.Product;
using OnlineShop.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Users
{
    public class EfCommandUpdateUser : IUpdateUserCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateUserValidator _validator;
        public EfCommandUpdateUser(OnlineShopContext context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;
        public string Name => "EfCommandUpdateUser";

        public void Execute(UpdateUserRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findUser = _context.Users.Find(request.Id);
            if (findUser == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            var User = _context.Users.Where(x => x.Id == request.Id).FirstOrDefault();
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
