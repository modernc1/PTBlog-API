using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Authentication.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using System.Data;


namespace PTBlog.Application.Authentication.command.LoginCommand; 

internal class LoginCommandHandler(ILogger<LoginCommandHandler> logger,
    UserManager<User> userManager,
    ITokenRepository tokenRepository) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Login Of User: {@User}", request);
        var response = new LoginResponse();
        
        //check Email
        var identityUser = await userManager.FindByEmailAsync(request.Email);
        if (identityUser is not null)
        {
            //check password
            var CheckPassword = await userManager.CheckPasswordAsync(identityUser, request.Password);

            if (CheckPassword)
            {
                var Roles = await userManager.GetRolesAsync(identityUser);
                
                response.Email = request.Email;
                response.Roles = Roles.ToList();
                response.Token = tokenRepository.CreateJwtToken(identityUser, Roles.ToList());
                response.RefreshToken = tokenRepository.GenerateRefreshTokenString();

                identityUser.RefreshToken = response.RefreshToken;
                identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddHours(12);

                await userManager.UpdateAsync(identityUser);
            }
            else
            {
                response.Errors = new List<IdentityError>
                {
                    new () {Code="Wrong Password", Description= "خطأ في كلمة السر يرجى المحاولة مجددا"}
                };
            }

        }
        else
        {
            response.Errors = new List<IdentityError>
                {
                    new () {Code="Wrong Email", Description= "خطأ في البريد الإلكتروني"}
                };
        }

        return response;
    }
}
