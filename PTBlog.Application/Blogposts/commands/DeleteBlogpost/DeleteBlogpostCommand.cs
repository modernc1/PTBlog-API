using MediatR;


namespace PTBlog.Application.Blogposts.commands.DeleteBlogpost;

public class DeleteBlogpostCommand : IRequest
{
    public Guid Id { get; set; }
}
