using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTBlog.Application.BlogImages.commands.DeleteBlogImage;
using PTBlog.Application.BlogImages.commands.UploadBlogImage;
using PTBlog.Application.BlogImages.DTO;
using PTBlog.Application.BlogImages.Queries.GetAllQuery;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Static;

namespace PTBlog.API.Controllers
{
    [ApiController]
    [Route("api/Images")]
    public class BlogImagesController(IMediator mediator) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var Images = await mediator.Send(new GetAllBlogImageQuery());
            if(Images == null)
            {
                return NotFound();
            }
            
            return Ok(Images);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] UploadBlogImageCommand command)
        {
            command.DateCreated = DateTime.Now;

            var imageDTO = await mediator.Send(command);

            
            //ValidateFileUpload(file);



            return Ok(imageDTO);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] int id)
        {
            if(await mediator.Send(new DeleteBlogImageCommand() { Id = id }))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        //private void ValidateFileUpload(IFormFile file)
        //{
        //    if (!StaticData.AllowedImageExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
        //    {
        //        ModelState.AddModelError("file", "Unsupported File Format");
        //    }

        //    if(file.Length > 10485760)
        //    {
        //        ModelState.AddModelError("file", "File Size Cann't be more than 10MB");
        //    }
        //}
    }
}
