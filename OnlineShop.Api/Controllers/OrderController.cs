using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Queries.Orders;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Orders;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly UseCaseExecutor _useCaseHandler;
        public OrderController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch orderSearch, [FromServices] IGetOrderQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, orderSearch));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] AddOrderRequest addOrderRequest, [FromServices] IAddOrdersCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, addOrderRequest);
            return NoContent();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOrderRequest request, [FromServices] IUpdateOrderCommand command)
        {
            request.Id = id;

            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
