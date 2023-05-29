using Azure.Core;
using FluentValidation;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Implementation.Commands.Categories
{
    public class EfCommandUpdateCategory : IUpdateCategoryCommand
    {

        private readonly OnlineShopContext _context;
        private readonly UpdateCategoryValidator _validator;

        public EfCommandUpdateCategory(OnlineShopContext context, UpdateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id =>6;

        public string Name =>"EfCommandUpdateCategory";

        public void Execute(UpdateCategoryRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);
            var findCategory = _context.Categories.Find(reqeust.Id);
            if (findCategory == null)
            {
                throw new EntityNotFoundException(reqeust.Id, typeof(City));
            }

            var Category = _context.Categories.Where(x => x.Id == reqeust.Id).FirstOrDefault();

            Category.Name = reqeust.CategoryName;

            _context.SaveChanges();
        }
    }
}
