

using MediatR;
using PTBlog.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PTBlog.Application.Blogposts.queries.GetBlogPostsCount;

internal class GetBlogPostsCountQueryHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<GetBlogPostsCountQuery, int>
{
    public async Task<int> Handle(GetBlogPostsCountQuery request, CancellationToken cancellationToken)
    {
        int count = await blogPostRepository.GetBlogpostsCount(request.filter == null? null : request.filter);

        return count;
    }
}
