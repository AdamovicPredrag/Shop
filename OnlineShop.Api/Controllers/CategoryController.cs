using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Application.Base;
using OnlineShop.Application.Commands.Categories;
using OnlineShop.Application.Commands.States;
using OnlineShop.Application.Queries.Categories;
using OnlineShop.Application.Queries.States;
using OnlineShop.Application.Requests.Categories;
using OnlineShop.Application.Requests.Shop;
using OnlineShop.Application.Requests.States;
using OnlineShop.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseHandler;

        public CategoryController(UseCaseExecutor executor)
        {
            _useCaseHandler = executor;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch categorySearch, [FromServices] IGetCategoryQuery query)
        {
            return Ok(_useCaseHandler.ExecuteQuery(query, categorySearch));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryRequest addCategoryRequest, [FromServices] IAddCategoryCommand command)
        {
                _useCaseHandler.ExecuteCommand(command, addCategoryRequest);
                return NoContent();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryRequest request, [FromServices] IUpdateCategoryCommand command)
        {
                request.Id = id;

                _useCaseHandler.ExecuteCommand(command, request);

                return StatusCode(StatusCodes.Status201Created);          
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
                _useCaseHandler.ExecuteCommand(command, id);
                return StatusCode(StatusCodes.Status204NoContent);            
        }
    }
}
