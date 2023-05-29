using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Users;
using OnlineShop.Application.DataTransfer.User;
using OnlineShop.Application.Queries.Cities;
using OnlineShop.Application.Queries.User;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Users;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UseCaseExecutor _useCaseHandler;

        public UserController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch userSearch, [FromServices] IGetUsersQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, userSearch));
        }

        // GET: api/<UserController>/current
        [HttpGet]
        [Route("current")]
        public IActionResult Get([FromServices] IGetUserQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, null));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Route("UpdateCurrentUser")]
        public IActionResult Put( [FromBody] UpdateCurrentUserRequest request, [FromServices] IUpdateCurrentUserCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserRequest request, [FromServices] IUpdateUserCommand command)
        {
            request.Id = id;

            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
