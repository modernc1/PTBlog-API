using Microsoft.AspNetCore.Identity;

namespace PTBlog.Application.UsersManagement.DTO
{
    public class EditUserRoleResponse
    {
        public string email { get; set; } = default!;
        public string oldRole { get; set; } = default!;
        public string newRole { get; set; } = default!;
        public List<IdentityError>? Errors { get; set; } = null;

    }
}
