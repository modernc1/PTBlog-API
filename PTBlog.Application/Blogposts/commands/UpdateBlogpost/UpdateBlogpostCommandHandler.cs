using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Blogposts.commands.UpdateBlogpost;

internal class UpdateBlogpostCommandHandler(ILogger<UpdateBlogpostCommandHandler> logger,
    IBlogPostRepository blogPostRepository,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<UpdateBlogpostCommand, BlogpostResponse>
{
    public async Task<BlogpostResponse> Handle(UpdateBlogpostCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating Blog Post of Id: {request.Id}");

        var blogpostFromDb = await blogPostRepository.GetAsync(request.Id) ?? throw new Exception($"Blog Post of Id: {request.Id} Not Found");


        blogpostFromDb.Title = request.Title;
        blogpostFromDb.ShortDescription = request.ShortDescription;
        blogpostFromDb.Content = request.Content;
        blogpostFromDb.FeatureImageUrl = request.FeatureImageUrl;
        blogpostFromDb.Author = request.Author;
        blogpostFromDb.DateCreated = request.DateCreated;
        blogpostFromDb.UrlHandle = request.UrlHandle;
        blogpostFromDb.IsVisible = request.IsVisible;
        var oldCategories = blogpostFromDb.Categories;
        blogpostFromDb.Categories = new List<BlogPostCategory>();

        foreach (var catId in request.Categories)
        {
            var category = await categoryRepository.GetAsync(catId);
            if(category != null)
            {
                blogpostFromDb.Categories.Add(new BlogPostCategory
                {
                    Category = category
                });
            }
        }

        await blogPostRepository.UpdateAsync(blogpostFromDb);

        var test = mapper.Map<BlogpostResponse>(blogpostFromDb);
        return test;

    }
}
