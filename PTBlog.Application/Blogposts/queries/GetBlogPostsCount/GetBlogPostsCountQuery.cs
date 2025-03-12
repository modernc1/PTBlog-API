

using MediatR;

namespace PTBlog.Application.Blogposts.queries.GetBlogPostsCount;

public class GetBlogPostsCountQuery : IRequest<int>
{
    public string? filter { get; set; } = null;
}
