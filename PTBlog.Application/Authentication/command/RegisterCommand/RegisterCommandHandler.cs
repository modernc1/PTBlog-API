using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Authentication.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Static;

namespace PTBlog.Application.Authentication.command.RegisterCommand;

internal class RegisterCommandHandler(ILogger<RegisterCommandHandler> logger,
    UserManager<User> userManager) : IRequestHandler<RegisterCommand, RegisterResponse>
{

    private async Task<bool> _isEmailExist(string email)
    {
        var existingUser = await userManager.FindByEmailAsync(email);
        if (existingUser != null) return true;
        else return false;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Regester New User: {@request}", request);

        var response = new RegisterResponse();

        if (await _isEmailExist(request.Email))
        {
            logger.LogWarning("Email already exists: {Email}", request.Email);

            response.Errors = new List<IdentityError>()
            {
                new IdentityError() { Code = "DuplicateEmail", Description = "هذا الإيميل موجود مسبقا" }
            };

            return response;
        }

        var user = new User()
        {
            UserName = request.UserName,
            Email = request.Email.Trim(),
            FirstName = request.FirstName,
            LastName = request.LastName
        };


        // to ensure that create is successfult assign it to identity result
        var IdentityResult = await userManager.CreateAsync(user, request.Password);

        if (IdentityResult.Succeeded)
        {
            //in case it succeeded add roles and assign it again to identity result to ensure the success
            IdentityResult = await userManager.AddToRoleAsync(user, StaticData.ReaderRole);

            if (IdentityResult.Succeeded)
            {
                response.Success = true;
                response.User = user;
            }
            else
            {
                logger.LogInformation("Error Occured while assigning Role{RoleName} To User: {@user}", StaticData.ReaderRole, user);
                if (IdentityResult.Errors.Any())
                {
                    foreach (var error in IdentityResult.Errors)
                    {
                        logger.LogError("ErrorCode:{code}\nErrorDescription:{des}", error.Code, error.Description);
                    }
                }

            }
        }
        else
        {
            logger.LogError("Error Occured Regitring User: {@Request}", request);
            if (IdentityResult.Errors.Any())
            {
                foreach (var error in IdentityResult.Errors)
                {
                    logger.LogError("ErrorCode:{code}\nErrorDescription:{des}", error.Code, error.Description);
                }
            }
        }

        response.Errors = IdentityResult.Errors.ToList();

        return response;
    }
}
