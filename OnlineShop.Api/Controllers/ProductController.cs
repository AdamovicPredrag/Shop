using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Queries.Products;
using OnlineShop.Application.Queries.Shops;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Product;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions =>
        new List<string> { ".jpg", ".png", ".jpeg" };
        private readonly UseCaseExecutor _useCaseHandler;

        public ProductController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch shopSearch, [FromServices] IGetProductQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, shopSearch));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromForm] AddProductWithImageDto addProductRequest, [FromServices] IAddProductCommand command)
        {
            if (addProductRequest.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(addProductRequest.Image.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                addProductRequest.Image.CopyTo(stream);
                addProductRequest.ImageFileName = fileName;
            }

            _useCaseHandler.ExecuteCommand(command, addProductRequest);
            return NoContent();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductRequest request, [FromServices] IUpdateProductCommand command)
        {
            request.Id = id;

            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
