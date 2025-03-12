

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PTBlog.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MinLength(3), MaxLength(30)]
    public string Name { get; set; } = default!;

    public string UrlHandle { get; set; } = default!;
    [JsonIgnore]
    public ICollection<BlogPostCategory> BlogPosts { get; set; } = [];
}
