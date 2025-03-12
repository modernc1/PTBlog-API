

namespace PTBlog.Application.UsersManagement.DTO
{
    public class UserManagementModel
    {
        public string username { get; set; } = default!;
        public string email { get; set; } = default!;
        public string role { get; set; } = default!;
        public string status { get; set; } = default!;
    }
}
