

using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.BlogImages.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.BlogImages.commands.UploadBlogImage;

internal class UploadBlogImageCommandHandler(ILogger<UploadBlogImageCommandHandler> logger,
    IImageRepository imageRepository) : IRequestHandler<UploadBlogImageCommand, BlogImageDTO>
{
    public async Task<BlogImageDTO> Handle(UploadBlogImageCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading Image: {@request}", request);

        var blogImage = new BlogImage()
        {
            Title = request.Title,
            FileName = request.FileName,
            FileExtension = Path.GetExtension(request.File.FileName.ToLower()),
            DateCreated = request.DateCreated
        };
        blogImage = await imageRepository.UploadImageAsync(blogImage, request.File);

        var imageDTO = new BlogImageDTO()
        {
            Title = blogImage.Title,
            FileName = blogImage.FileName,
            FileExtension = blogImage.FileExtension,
            DateCreated = blogImage.DateCreated,
            Url = blogImage.Url
        };

        return imageDTO;
    }
}
