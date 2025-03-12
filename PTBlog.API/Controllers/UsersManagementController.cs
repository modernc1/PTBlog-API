using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTBlog.Application.UsersManagement.commands.EditUserRole;
using PTBlog.Application.UsersManagement.queries.getAllUsers;
using PTBlog.Domain.Static;

namespace PTBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersManagementController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }
        [HttpPut("{email}")]
        public async Task<IActionResult> EditUserInfo([FromBody]EditUserRoleCommand command)
        {
            var response = await mediator.Send(command);
            if(response.Errors != null)
            {
                foreach (var err in response.Errors!)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return ValidationProblem(ModelState);
            }

            return Ok(response);
        }
    }
}
