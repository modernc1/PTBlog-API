using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTBlog.Application.Blogposts.commands.AddBlogpost;
using PTBlog.Application.Blogposts.commands.DeleteBlogpost;
using PTBlog.Application.Blogposts.commands.UpdateBlogpost;
using PTBlog.Application.Blogposts.queries.GetAll;
using PTBlog.Application.Blogposts.queries.GetBlogpostByUrlHandle;
using PTBlog.Application.Blogposts.queries.GetBlogPostsCount;
using PTBlog.Application.Blogposts.queries.GetById;
using PTBlog.Domain.Static;

namespace PTBlog.API.Controllers
{
    [Route("api/BlogPosts")]
    [ApiController]
    public class BlogPostsController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllBlogpostQuery query)
        {
            var postsList = await mediator.Send(query);

            if (!postsList!.Any()) return NotFound();

            return Ok(postsList);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetBlogPostsCount([FromQuery] GetBlogPostsCountQuery query)
        {
            var count = await mediator.Send(query);
            
            return Ok(count);
        }

        [HttpGet]
        [Route("{id:guid}")] //if didn't specify type will give possible error with HetUrlHandle Get Method
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetBlogpostByIdQuery() { Id = id };

            var response = await mediator.Send(query);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpGet("{urlHandle}")]
        public async Task<IActionResult> GetUrlHandle([FromRoute] string urlHandle)
        {
            var blog = await mediator.Send(new GetBlogpostByUrlHandleQuery() { UrlHandle = urlHandle });
            if (blog == null) return NotFound();

            return Ok(blog);
        }

        
        [HttpPost]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> CreateBlogpost([FromBody] AddBlogpostCommand command)
        {
            
            var Blogpost = await mediator.Send(command);

            return CreatedAtAction(nameof(Get), new {id = Blogpost.Id}, Blogpost);
        }

        
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> UpdateBlogpost([FromRoute]Guid id, [FromBody] UpdateBlogpostCommand command)
        {
            command.Id = id;

            var response = await mediator.Send(command);
            
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response); ;
        }

        
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = $"{StaticData.WriterRole},Admin")]
        public async Task<IActionResult> DeleteBlogpost([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteBlogpostCommand() { Id = id });

            return NoContent();
        }
        
    }
}
