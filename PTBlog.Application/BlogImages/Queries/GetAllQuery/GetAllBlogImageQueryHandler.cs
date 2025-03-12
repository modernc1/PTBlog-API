using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;


namespace PTBlog.Application.BlogImages.Queries.GetAllQuery
{
    internal class GetAllBlogImageQueryHandler(ILogger<GetAllBlogImageQueryHandler> logger,
        IImageRepository imageRepository) : IRequestHandler<GetAllBlogImageQuery, List<BlogImage>?>
    {
        public async Task<List<BlogImage>?> Handle(GetAllBlogImageQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Blog Images");

            var images = await imageRepository.GetAllAsync();

            return images;
        }
    }
}
