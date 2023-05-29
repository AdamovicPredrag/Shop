using FluentValidation;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Requests.Product;
using OnlineShop.DataAccess;
using OnlineShop.Domain;
using OnlineShop.Implementation.Validators.Product;
using static System.Net.Mime.MediaTypeNames;


namespace OnlineShop.Implementation.Commands.Product
{
    public class EfCommandAddProduct : IAddProductCommand
    {
        private readonly OnlineShopContext _context;
        private readonly AddProductValidator _validator;

        public EfCommandAddProduct(OnlineShopContext context, AddProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfCommandAddCity";

        public void Execute(AddProductRequest request)
        {
            _validator.ValidateAndThrow(request);
            var Product = new Domain.Product();

            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                var image = new HashSet<Domain.Image>
                {
                    new Domain.Image{Path = request.ImageFileName}
                };

                Product.Name = request.Name;
                Product.Description = request.Description;
                Product.Price = request.Price;
                Product.Size = request.Size;
                Product.Images = image;
                Product.IdShop = request.IdShop;
                Product.IdCategory = request.CategoryId;
            }
            else
            {
                Product.Name = request.Name;
                Product.Description = request.Description;
                Product.Price = request.Price;
                Product.Size = request.Size;
                Product.IdShop = request.IdShop;
                Product.IdCategory = request.CategoryId;
            
            }

            _context.Products.Add(Product);
            _context.SaveChanges();
        }
    }
}
