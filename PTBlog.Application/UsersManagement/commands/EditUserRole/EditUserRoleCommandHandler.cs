using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PTBlog.Application.UsersManagement.DTO;
using PTBlog.Domain.Entities;

namespace PTBlog.Application.UsersManagement.commands.EditUserRole;

internal class EditUserRoleCommandHandler(ILogger<EditUserRoleCommandHandler> logger,
    UserManager<User> userManager) : IRequestHandler<EditUserRoleCommand, EditUserRoleResponse>
{
    public async Task<EditUserRoleResponse> Handle(EditUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"edit user role for user {request.email}");
        var response = new EditUserRoleResponse();
        var user = await userManager.FindByEmailAsync(request.email);
        if(user == null)
        {
            response.Errors = new List<IdentityError>()
            {
                new IdentityError() { Code = "", Description = "لم يتم العثور على المستخدم" }
            };
        }
        else
        {
            var oldRolesList = await userManager.GetRolesAsync(user);
            var isAdmin = oldRolesList.Contains("Admin");
            if (isAdmin)
            {
                response.Errors = new List<IdentityError>()
                {
                    new IdentityError() {Code="", Description="لا يمكن تغيير صلاحية هذا الحساب"}
                };
                return response;
            }
            var identityResult = await userManager.RemoveFromRoleAsync(user, request.oldRole);
         
            if (!identityResult.Succeeded) 
            {
                response.Errors = new List<IdentityError>()
                {
                    new IdentityError() {Code="", Description="حدث خطأ يرجى التأكد من البيانات"}
                };
                return response;
            }

            identityResult = await userManager.AddToRoleAsync(user, request.newRole);

            if (!identityResult.Succeeded)
            {
                response.Errors = new List<IdentityError>()
                {
                    new IdentityError() {Code="", Description="حدث خطأ يرجى التأكد من البيانات"}
                };
                return response;
            }

            response.email = request.email;
            response.newRole = request.newRole;
            response.oldRole = request.oldRole;
        }

        return response;
    }
}
