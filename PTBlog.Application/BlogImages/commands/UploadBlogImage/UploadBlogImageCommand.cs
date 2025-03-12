using MediatR;
using Microsoft.AspNetCore.Http;
using PTBlog.Application.BlogImages.DTO;


namespace PTBlog.Application.BlogImages.commands.UploadBlogImage;

public class UploadBlogImageCommand : IRequest<BlogImageDTO>
{

    public string FileName { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string? Url { get; set; } = default!;
    public IFormFile File { get; set; } = default!;
    public string? FileExtension { get; set; } = default!;
    public DateTime DateCreated { get; set; }
}
