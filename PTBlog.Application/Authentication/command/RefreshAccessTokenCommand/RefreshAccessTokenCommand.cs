using MediatR;
using PTBlog.Application.Authentication.DTO;


namespace PTBlog.Application.Authentication.command.RefreshAccessTokenCommand
{
    public class RefreshAccessTokenCommand : IRequest<LoginResponse>
    {
        public string JwtToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
    }
}
