using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTBlog.Application.Authentication.command.LoginCommand;
using PTBlog.Application.Authentication.command.RefreshAccessTokenCommand;
using PTBlog.Application.Authentication.command.RegisterCommand;

namespace PTBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : Controller
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var response = await mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }
            else if(response.Errors != null)
            {
                foreach(var err in response.Errors!)
                {
                    ModelState.AddModelError("",err.Description);
                }
                return ValidationProblem(ModelState);
            }

            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await mediator.Send(command);

            if (response.Errors is not null)
            {
                foreach(var err in response.Errors!)
                {
                    ModelState.AddModelError("", err.Description);
                }

                return ValidationProblem(ModelState);
            }

            return Ok(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshAccessTokenCommand command)
        {
            var response = await mediator.Send(command);
            if(response.Errors is not null)
            {
                foreach(var err in response.Errors!)
                {
                    ModelState.AddModelError("", err.Description);
                }

                return ValidationProblem(ModelState);
            }

            return Ok(response);
        }
    }
}
