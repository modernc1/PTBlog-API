

using PTBlog.Domain.Entities;

namespace PTBlog.Application.Categories.DTO;

public class CategoryResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string UrlHandle { get; set; } = default!;

    public ICollection<BlogPost> BlogPosts { get; set; } = [];

}
