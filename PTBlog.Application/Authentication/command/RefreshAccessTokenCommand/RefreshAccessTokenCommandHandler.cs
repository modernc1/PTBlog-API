

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Authentication.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Authentication.command.RefreshAccessTokenCommand
{
    internal class RefreshAccessTokenCommandHandler(ILogger<RefreshAccessTokenCommandHandler> logger,
        ITokenRepository tokenRepository,
        UserManager<User> userManager) : IRequestHandler<RefreshAccessTokenCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(RefreshAccessTokenCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("refreshToken");

            // get principle to know the name of user to search him in db and find his refreshtoken
            var principle = tokenRepository.GetTokenPrincipal(request.JwtToken.TrimStart());
            var response = new LoginResponse();

            if (principle?.Identity?.Name == null)
            {
                response.Errors = new List<IdentityError>
                {
                    new () {Code="Error Occur", Description= "Error Occur when try to refresh access token"}
                };
                return response;
            }

            var identityUser = await userManager.FindByNameAsync(principle.Identity.Name);

            var temp1 = identityUser is null;
            var temp2 = identityUser!.RefreshToken != request.RefreshToken;
            var temp3 = identityUser.RefreshTokenExpiry < DateTime.UtcNow;
            //in case refresh token doesn't match that in db or expiry date is over
            if ( temp1 || temp2 || temp3)
            {
                response.Errors = new List<IdentityError>
                {
                    new () {Code="Error Occur", Description= "The session is expired please log in again"}
                };
                return response;
            }

            //the remain same as loginCommandHandler
            var Roles = await userManager.GetRolesAsync(identityUser);
            response.Email = identityUser.Email;
            response.Roles = Roles.ToList();
            response.Token = tokenRepository.CreateJwtToken(identityUser, Roles.ToList());
            response.RefreshToken = tokenRepository.GenerateRefreshTokenString();

            //update refreshtoken and expirey date in db
            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddHours(12);

            await userManager.UpdateAsync(identityUser);

            return response;
        }

        
    }
}
