using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Contacts;
using OnlineShop.Application.Requests.Contact;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public ContactController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] ContactRequest request, [FromServices] IContactCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
