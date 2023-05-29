using AutoMapper;
using FluentValidation;
using OnlineShop.Application.Commands.Categories;
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
    public class EfCommandAddCategory : IAddCategoryCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddCategoryValidator _validator;
      

        public EfCommandAddCategory(OnlineShopContext context, AddCategoryValidator validator)
        {
            _context = context;     
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfCommandAddCategory";

        public void Execute(AddCategoryRequest request)
        {
            _validator.ValidateAndThrow(request);
            var Category = new Category
            {
                Name = request.Name,
            };
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }
    }
}
