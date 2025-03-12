using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Blogposts.queries.GetById
{
    internal class GetBlogpostByIdQueryHandler(ILogger<GetBlogpostByIdQueryHandler> logger,
        IBlogPostRepository blogPostRepository,
        IMapper mapper) : IRequestHandler<GetBlogpostByIdQuery, BlogpostResponse?>
    {
        public async Task<BlogpostResponse?> Handle(GetBlogpostByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get Blog Post of Id: {id}", request.Id);

            var blogpost = await blogPostRepository.GetAsync(request.Id);
            if (blogpost == null) return null;

            var blogpostResponse = mapper.Map<BlogpostResponse>(blogpost);

            return blogpostResponse;
        }
    }
}
