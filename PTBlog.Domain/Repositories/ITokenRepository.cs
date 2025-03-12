

using PTBlog.Domain.Entities;
using System.Security.Claims;

namespace PTBlog.Domain.Repositories;

public interface ITokenRepository
{
    string CreateJwtToken(User user, List<String> roles);
    string GenerateRefreshTokenString();
    ClaimsPrincipal GetTokenPrincipal(string JwtToken);
}
