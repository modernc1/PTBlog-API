using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PTBlog.Infrastructure.Repositories
{
    internal class TokenRepository(IConfiguration configuration) : ITokenRepository
    {
        public string CreateJwtToken(User user, List<string> roles)
        {
            //Create Claims From Roles
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!),
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //Use Claims To Generat Jwt Token
                //to generate token we need the security key that we defined in appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            //then use key to define credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audiance"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            //return Token
                                               //Write token as string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetTokenPrincipal(string JwtToken)
        {
            try
            {
                if (string.IsNullOrEmpty(JwtToken)) throw new ArgumentNullException(JwtToken);
                //get security key from appsetting.json

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var validation = new TokenValidationParameters() //as it is in program.cs
                {
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],  //we will add issuer in appsetting.json file and configure it here
                    ValidAudience = configuration["Jwt:Audiance"]
                };

                var isValid = new JwtSecurityTokenHandler().ValidateToken(JwtToken, validation, out _);
                return isValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return new ClaimsPrincipal();
        }
    }
}
