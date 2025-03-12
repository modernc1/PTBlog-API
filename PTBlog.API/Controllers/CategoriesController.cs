using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTBlog.Application.Categories.Commands.AddCategory;
using PTBlog.Application.Categories.Commands.DeleteCategory;
using PTBlog.Application.Categories.Commands.EditCategory;
using PTBlog.Application.Categories.Queries;
using PTBlog.Application.Categories.Queries.GetCategoryById;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Static;

namespace PTBlog.API.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery query)
        {
            
            var Categories = await mediator.Send(query);
            return Ok(Categories);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var category = await mediator.Send(new GetCategoryByIdQuery() { Id = id });

            return Ok(category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] EditCategoryCommand command)
        {   
            command.Id = id;
            await mediator.Send(command);
            
            return CreatedAtAction(nameof(Get), new {id = command.Id} ,command);
        }

        [HttpPost]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> CreateCategory([FromBody]AddCategoryCommand command)
        {
            command.Id = Guid.NewGuid();

            await mediator.Send(command);

            return CreatedAtAction(nameof(Get), new {id = command.Id}, command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id)
        {

            await mediator.Send(new DeleteCategoryCommand() { Id = Id });

            return NoContent();
        }
    }
}
