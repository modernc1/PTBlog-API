using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTBlog.Domain.Entities
{
    public class BlogPostCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BlogPost))]
        public Guid BlogPostId { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        [JsonIgnore]
        public BlogPost BlogPost { get; set; } = default!;
        [JsonIgnore]
        public Category Category { get; set; } = default!;
    }
}
