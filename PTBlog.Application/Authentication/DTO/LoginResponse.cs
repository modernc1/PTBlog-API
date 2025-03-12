using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Authentication.DTO
{
    public class LoginResponse
    {
        public string? Email { get; set; } = default!;

        public string? Token { get; set; } = default!;
        public string? RefreshToken { get; set; } = default!;

        public List<string>? Roles { get; set; } = [];

        public List<IdentityError>? Errors { get; set; } = null;
    }
}
