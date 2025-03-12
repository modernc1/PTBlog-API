using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Blogposts.commands.DeleteBlogpost;

internal class DeleteBlogpostCommandHandler(ILogger<DeleteBlogpostCommand> logger,
    IBlogPostRepository blogPostRepository) : IRequestHandler<DeleteBlogpostCommand>
{
    public async Task Handle(DeleteBlogpostCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting Blog Post With Id: {request.Id}");

        var BlogpostFromDb = await blogPostRepository.GetAsync(request.Id);

        if (BlogpostFromDb == null) throw new Exception($"Blog Post With Id: {request.Id} Not Found");
        
        await blogPostRepository.DeleteAsync(BlogpostFromDb);
    }
}
