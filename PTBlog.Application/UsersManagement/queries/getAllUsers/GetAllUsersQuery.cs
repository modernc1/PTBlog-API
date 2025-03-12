
using MediatR;
using PTBlog.Application.UsersManagement.DTO;

namespace PTBlog.Application.UsersManagement.queries.getAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserManagementModel>>
    {
        public string? filter { get; set; } = null;
    }
}
