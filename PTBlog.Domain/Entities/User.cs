using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace PTBlog.Domain.Entities;

public class User : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set;} = default!;

    [Required]
    [EmailAddress]
    public override string? Email { get => base.Email; set => base.Email = value; }
    public string? RefreshToken { get; set; } = default!;
    public DateTime? RefreshTokenExpiry { get; set; } = default!;

}
