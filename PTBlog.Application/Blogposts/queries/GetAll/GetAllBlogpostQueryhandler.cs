using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Blogposts.queries.GetAll
{
    internal class GetAllBlogpostQueryhandler(ILogger<GetAllBlogpostQueryhandler> logger,
        IBlogPostRepository blogPostRepository,
        IMapper mapper) : IRequestHandler<GetAllBlogpostQuery, List<BlogpostResponse>?>
    {
        public async Task<List<BlogpostResponse>?> Handle(GetAllBlogpostQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get All BlogPost");

            var blogPosts = await blogPostRepository.GetAllAsync(request.filter != null ? request.filter : null,
                                                                 request.sortBy, request.sortDirection,
                                                                 request.pageNumber, request.pageSize);

            if (blogPosts == null) return null;


            //var response = new List<BlogpostResponse>();
            //foreach(var post in blogPosts)
            //{
            //    var temp = new BlogpostResponse()
            //    {
            //        Id = post.Id,
            //        Author = post.Author,
            //        Content = post.Content,
            //        DateCreated = post.DateCreated,
            //        FeatureImageUrl = post.FeatureImageUrl,
            //        ShortDescription = post.ShortDescription,
            //        IsVisible = post.IsVisible,
            //        Title = post.Title,
            //        UrlHandle = post.UrlHandle,
            //        Categories = new List<Category>()
            //    };

            //    foreach(var cat in post.Categories)
            //    {
            //        temp.Categories.Add(cat.Category);
            //    }

            //    response.Add(temp);
            //}
            var response = mapper.Map<List<BlogpostResponse>>(blogPosts);

            return response;
        }

    }
}
