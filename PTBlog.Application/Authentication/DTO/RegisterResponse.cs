using Microsoft.AspNetCore.Identity;
using PTBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Authentication.DTO
{
    public class RegisterResponse
    {
        public bool Success { get; set; } = false;
        public User? User { get; set; } = null;
        public List<IdentityError>? Errors { get; set; } = null; 
    }
}
