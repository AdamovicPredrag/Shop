using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Queries.Shops;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public ShopController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }


        // GET: api/<ShopController>
        [HttpGet]
        public IActionResult Get([FromQuery] ShopSearch shopSearch, [FromServices] IGetShopsQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, shopSearch));
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShopController>
        [HttpPost]
        public IActionResult Post([FromBody] AddShopRequest addShopRequest, [FromServices] IAddShopCommand command)
        {        
                _useCaseHandler.ExecuteCommand(command, addShopRequest);
                return NoContent();
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateShopRequest request, [FromServices] IUpdateShopCommand command)
        {
                request.Id = id;

                _useCaseHandler.ExecuteCommand(command, request);

                return StatusCode(StatusCodes.Status201Created);            
        }

        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteShopCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
