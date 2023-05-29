using FluentValidation;
using OnlineShop.Application.Commands.Authorisation;
using OnlineShop.Application.Requests.Authorisaation;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Authorisation;
using OnlineShop.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Authoiisation
{
    public class EfCommandRegiterUser : IRegisterUserCommand
    {
        private readonly OnlineShopContext _context;
        private readonly RegisterUserValidator _validator;
        private IEnumerable<int> UserUseCases = new List<int> { 3,4,5,6 };

        public EfCommandRegiterUser(OnlineShopContext context, RegisterUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 1;

        public string Name => "EfCommandRegisterUser";

        public void Execute(RegisterUserRequest request)
        {

            _validator.ValidateAndThrow(request);


            var User = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address,
                CityId = request.CityId

            };
            _context.Users.Add(User);
            _context.SaveChanges();


            int Id = User.Id;

            foreach (var useCaseId in UserUseCases)
            {
                _context.UserUseCases.Add(new Domain.UserUseCases
                {
                    IdUser = Id,
                    IdUseCase = useCaseId
                });
            }
            _context.SaveChanges();


        }
    }
}
