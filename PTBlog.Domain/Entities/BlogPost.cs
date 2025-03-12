

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PTBlog.Domain.Entities;

public class BlogPost
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string ShortDescription { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    public string FeatureImageUrl { get; set; } = default!;

    public string UrlHandle { get; set; } = default!;

    public DateTime DateCreated { get; set; }

    public string Author { get; set; } = default!;

    public bool IsVisible { get; set; } = default!;
    [JsonIgnore]
    public ICollection<BlogPostCategory> Categories { get; set; } = [];

    
}
