using FluentValidation;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Exceptions;
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
    public class EfCommandDeleteProduct : IDeleteProductCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteProductValidator _validator;

        public EfCommandDeleteProduct(OnlineShopContext context, DeleteProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "EfDeleteProductCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findProduct = _context.Products.Find(request);
            if (findProduct == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Product));
            }

            findProduct.IsDeleted = true;
            findProduct.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
