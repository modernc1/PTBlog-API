using PTBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Blogposts.DTO
{
    public class BlogpostResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string ShortDescription { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string FeatureImageUrl { get; set; } = default!;

        public string UrlHandle { get; set; } = default!;

        public DateTime DateCreated { get; set; }

        public string Author { get; set; } = default!;

        public bool IsVisible { get; set; } = default!;

        public ICollection<Category> Categories { get; set; } = [];
    }
}
