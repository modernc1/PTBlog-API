using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Blogposts.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Blogposts.commands.AddBlogpost;

internal class AddBlogpostCommandHandler(ILogger<AddBlogpostCommandHandler> logger,
    IBlogPostRepository blogPostRepository,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<AddBlogpostCommand, BlogpostResponse>
{
    public async Task<BlogpostResponse> Handle(AddBlogpostCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding New Blog Post");

        var blogpost = mapper.Map<BlogPost>(request);
        
        foreach(var Id in request.Categories)
        {
            var categoryFromDb = await categoryRepository.GetAsync(Id, true);
            if(categoryFromDb != null)
            {
               blogpost.Categories.Add(new BlogPostCategory
               {
                   Category = categoryFromDb
               });
            }
        }
        
        var DbBlogpost = await blogPostRepository.CreateAsync(blogpost);


        return mapper.Map<BlogpostResponse>(DbBlogpost);
    }
}
