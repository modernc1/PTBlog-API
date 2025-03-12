

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PTBlog.Application.UsersManagement.DTO;
using PTBlog.Domain.Entities;

namespace PTBlog.Application.UsersManagement.queries.getAllUsers;

internal class GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger,
    UserManager<User> userManager) : IRequestHandler<GetAllUsersQuery, List<UserManagementModel>>
{
    public async Task<List<UserManagementModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("getting all Users Query");
        var users = await userManager.Users.ToListAsync();
        
        var response = new List<UserManagementModel>();
        foreach (var user in users)
        {
            var role = await userManager.GetRolesAsync(user);
            response.Add(new UserManagementModel()
            {
                email = user.Email!,
                username = user.UserName!,
                role = role.First(),
                status = ""
            });
        }

        return response;
    }
}
