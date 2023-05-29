using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.States;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        // GET: api/<StateController>
        private readonly UseCaseExecutor _useCaseHandler;
        public StateController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] StateSearch stateSearch, [FromServices] IGetStatesQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, stateSearch));
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StateController>
        [HttpPost]
        public IActionResult Post([FromBody]AddStateRequest addStateRequest, [FromServices]IAddStateCommand command)
        {
                _useCaseHandler.ExecuteCommand(command, addStateRequest);
                return NoContent();
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStateRequest request, [FromServices] IUpdateStateCommand command )
        {
                request.Id = id;

                _useCaseHandler.ExecuteCommand(command, request);

                return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteStateCommand command)
        {
                _useCaseHandler.ExecuteCommand(command, id);
                return StatusCode(StatusCodes.Status204NoContent);            
        }
    }
}
