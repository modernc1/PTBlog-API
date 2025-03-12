
using MediatR;
using PTBlog.Application.Authentication.DTO;
using System.ComponentModel.DataAnnotations;

namespace PTBlog.Application.Authentication.command.LoginCommand;

public class LoginCommand : IRequest<LoginResponse>
{
    [EmailAddress]
    public string Email { get; set; } = default!;
    
    public string Password { get; set; } = default!;
}
