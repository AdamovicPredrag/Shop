using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Shop;

namespace OnlineShop.Implementation.Commands.Shop
{
    public class EfCommandAddShop : IAddShopCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddShopValidator _validator;

        public EfCommandAddShop(OnlineShopContext context, AddShopValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "EfCommandAddShop";

        public void Execute(AddShopRequest request)
        {
            _validator.ValidateAndThrow(request);

            var Shop = new OnlineShop.Domain.Shop
            {
                Name = request.Name,
                Description = request.Description,
                Phone = request.Phone,
                Address = request.Address,
                Email = request.Email,
                CityId = request.CityId,
            };
            _context.Shops.Add(Shop);
            _context.SaveChanges();
        }
    }
}
