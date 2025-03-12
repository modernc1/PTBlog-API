
using Microsoft.AspNetCore.Http;
using PTBlog.Domain.Entities;

namespace PTBlog.Domain.Repositories;

public interface IImageRepository
{
    Task<BlogImage> UploadImageAsync(BlogImage image, IFormFile file);

    Task<List<BlogImage>?> GetAllAsync();

    Task<bool> DeleteImageAsync(int Id);
}
