using MediatR;
using PTBlog.Application.UsersManagement.DTO;


namespace PTBlog.Application.UsersManagement.commands.EditUserRole;

public class EditUserRoleCommand : IRequest<EditUserRoleResponse>
{
    public string email { get; set; } = default!;
    public string oldRole { get; set; } = default!;
    public string newRole { get; set; } = default!;

}
