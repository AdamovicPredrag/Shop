using FluentValidation;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Product;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Cities;
using OnlineShop.Implementation.Validators.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Product
{
    public class EfCommandUpdateProduct : IUpdateProductCommand
    {
        private readonly OnlineShopContext _context;
        private readonly UpdateProductValidator _validator;
        public EfCommandUpdateProduct(OnlineShopContext context, UpdateProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 3;
        public string Name => "EfCommandUpdateProduct";
        public void Execute(UpdateProductRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findProduct = _context.Products.Find(request.Id);
            if (findProduct == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Product));
            }

            var Product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
                Product.Name = request.Name;
                Product.Description = request.Description;
                Product.Price = request.Price;
                Product.Size = request.Size;
                Product.IdShop = request.IdShop;
                Product.IdCategory = request.CategoryId;

            _context.SaveChanges();
        }
    }
}
