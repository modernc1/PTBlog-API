

using MediatR;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PTBlog.Application.Blogposts.commands.UpdateBlogpost;

public class UpdateBlogpostCommand : IRequest<BlogpostResponse>
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

    public ICollection<Guid> Categories { get; set; } = [];
}
