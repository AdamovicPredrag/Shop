using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Core;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Authorisation;
using OnlineShop.Application.Queries.Products;
using OnlineShop.Application.Requests.Authorisaation;
using OnlineShop.Application.Requests.User;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoirisationController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly JwtManager _manager;

        public AuthoirisationController(UseCaseExecutor executor, JwtManager manager)
        {
            _executor = executor;
            _manager = manager;
        }

        [HttpGet]
        //[Route("api/[controller]/logout")]
        public IActionResult Get()
        {  
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] LoginRequest request)
        {
                var token = _manager.MakeToken(request.UserName, request.Password);
                return Ok(new { token });
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Post([FromBody] RegisterUserRequest request, [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
