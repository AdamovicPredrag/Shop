using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.States;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public CityController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IActionResult Get([FromQuery] CitySearch citySearch, [FromServices] IGetCityQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, citySearch));
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCityRequest addCityRequest, [FromServices] IAddCityCommand command)
        {            
                _useCaseHandler.ExecuteCommand(command, addCityRequest);
                return NoContent();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCityRequest request, [FromServices] IUpdateCityCommand command)
        {
                request.Id = id;

                _useCaseHandler.ExecuteCommand(command, request);

                return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCityCommand command)
        {
                _useCaseHandler.ExecuteCommand(command, id);
                return StatusCode(StatusCodes.Status204NoContent);          
        }
    }
}
