

using PTBlog.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PTBlog.Application.Categories.DTO
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; } = default!;
        public string UrlHandle { get; set; } = default!;

        public ICollection<BlogPost> BlogPosts { get; set; } = [];

    }
}
