using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cart;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Queries.Cart;
using OnlineShop.Application.Queries.Categories;
using OnlineShop.Application.Requests.Cart;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public CartController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IActionResult Get([FromQuery] CartSearch cartSearch, [FromServices] IGetCartQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, cartSearch));
        }


        // POST api/<CartController>
        [HttpPost]
        public IActionResult Post([FromBody] AddToCartRequest addToCartRequest, [FromServices] IAddToCartCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, addToCartRequest);
            return NoContent();
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCartRequest request, [FromServices] IUpdateCartCommand command)
        {
            request.Id = id;

            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCartCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
