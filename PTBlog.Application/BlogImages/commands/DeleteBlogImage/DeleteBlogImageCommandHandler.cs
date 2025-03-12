using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Repositories;


namespace PTBlog.Application.BlogImages.commands.DeleteBlogImage
{
    internal class DeleteBlogImageCommandHandler(ILogger<DeleteBlogImageCommandHandler> logger,
        IImageRepository imageRepository) : IRequestHandler<DeleteBlogImageCommand, bool>
    {
        public async Task<bool> Handle(DeleteBlogImageCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting Image With ID: {image}", request.Id);

            return await imageRepository.DeleteImageAsync(request.Id);
        }
    }
}
