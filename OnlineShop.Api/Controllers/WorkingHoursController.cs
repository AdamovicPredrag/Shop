using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Cities;
using OnlineShop.Application.Commands.Shop;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Commands.WorkingHours;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Queries.WorkingHours;
using OnlineShop.Application.Requests.Cities;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.Application.Requests.WorkingHours;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public WorkingHoursController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<WorkingHoursController>
        [HttpGet]
        public IActionResult Get([FromQuery] WorkingHoursSearch workingHoursSearch, [FromServices] IGetWorkingHoursQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, workingHoursSearch));
        }

        // GET api/<WorkingHoursController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkingHoursController>
        [HttpPost]
        public IActionResult Post([FromBody] AddWorkingHoursRequest addWorkingHoursRequest, [FromServices] IAddWorkingHoursCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, addWorkingHoursRequest);
            return NoContent();
        }

        // PUT api/<WorkingHoursController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateWorkingHoursRequest request, [FromServices] IUpdateWorkingHoursCommand command)
        {
            request.Id = id;

            _useCaseHandler.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }
        // DELETE api/<WorkingHoursController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteWorkingHoursCommand command)
        {
            _useCaseHandler.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
