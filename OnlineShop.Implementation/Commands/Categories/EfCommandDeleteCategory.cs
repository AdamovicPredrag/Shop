using FluentValidation;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Exceptions;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Categories;
using OnlineShop.Implementation.Validators.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Categories
{
    public class EfCommandDeleteCategory : IDeleteCategoryCommand
    {
        private readonly OnlineShopContext _context;
        private readonly DeleteCategoryValidator _validator;

        public EfCommandDeleteCategory(OnlineShopContext context, DeleteCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfDeleteCategoryCommand";

        public void Execute(int reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var findCategory = _context.Categories.Find(reqeust);
            if (findCategory == null)
            {
                throw new EntityNotFoundException(reqeust, typeof(Category));
            }

            findCategory.IsDeleted = true;
            findCategory.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
