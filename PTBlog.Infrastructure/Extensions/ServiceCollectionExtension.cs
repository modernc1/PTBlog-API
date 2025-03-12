
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTBlog.Domain.Repositories;
using PTBlog.Infrastructure.Data;
using PTBlog.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using PTBlog.Domain.Entities;

namespace PTBlog.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(option => 
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<AuthDbContext>(option =>
               option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); //you can create identity tables in different database by change connection string


        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();

        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()//need provider Name
            .AddTokenProvider<DataProtectorTokenProvider<User>>("PTPlog") //^
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        });

        //add JWT Auth
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                AuthenticationType = "Jwt",
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],  //we will add issuer in appsetting.json file and configure it here
                ValidAudience = configuration["Jwt:Audiance"],
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });

        //finally Add Authentication to HTTP Pipeline in program.cs
        //Note Authentication in pipeline written before Authorization
    }
}
