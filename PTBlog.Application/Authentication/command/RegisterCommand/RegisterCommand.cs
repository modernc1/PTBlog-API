

using MediatR;
using PTBlog.Application.Authentication.DTO;
using PTBlog.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PTBlog.Application.Authentication.command.RegisterCommand;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string UserName { get; set; } = default!;
    [EmailAddress]
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;


}
