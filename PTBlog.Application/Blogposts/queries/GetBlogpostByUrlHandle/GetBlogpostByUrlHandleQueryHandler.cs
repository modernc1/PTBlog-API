
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Repositories;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace PTBlog.Application.Blogposts.queries.GetBlogpostByUrlHandle;

internal class GetBlogpostByUrlHandleQueryHandler(ILogger<GetBlogpostByUrlHandleQueryHandler> logger,
    IBlogPostRepository blogPostRepository,
    IMapper mapper) : IRequestHandler<GetBlogpostByUrlHandleQuery, BlogpostResponse?>
{
    public async Task<BlogpostResponse?> Handle(GetBlogpostByUrlHandleQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting Blogpost By UrlHandle: {urlHandle}", request.UrlHandle);

        var blogPostFromDb = await blogPostRepository.GetByUrlHandle(request.UrlHandle);

        if (blogPostFromDb == null) return null;

        var blogPost = mapper.Map<BlogpostResponse>(blogPostFromDb);

        return blogPost;
    }
}
