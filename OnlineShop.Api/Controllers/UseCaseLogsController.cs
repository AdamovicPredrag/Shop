using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Application.Base;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Queries.UseCaseLog;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.Application.Searches;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogsController : ControllerBase
    {

        private readonly UseCaseExecutor _useCaseHandler;

        public UseCaseLogsController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }

        // GET: api/<UseCaseLogsController>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch stateSearch, [FromServices] IGetUseCaseLogQuery query)
        {
                return Ok(_useCaseHandler.ExecuteQuery(query, stateSearch));   
        }

    }
}
