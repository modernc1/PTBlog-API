using MediatR;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Entities;


namespace PTBlog.Application.Blogposts.queries.GetById;

public class GetBlogpostByIdQuery : IRequest<BlogpostResponse?>
{
    public Guid Id { get; set; }
}
