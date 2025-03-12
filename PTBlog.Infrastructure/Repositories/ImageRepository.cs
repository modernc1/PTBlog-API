
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using PTBlog.Infrastructure.Data;

namespace PTBlog.Infrastructure.Repositories;

internal class ImageRepository(BlogDbContext dbContext,
    IWebHostEnvironment webHostEnvironment,
    IHttpContextAccessor httpContextAccessor) : IImageRepository
{
    public async Task<List<BlogImage>?> GetAllAsync()
    {
        var images = await dbContext.BlogImages.ToListAsync();

        return images;
    }
    public async Task<BlogImage> UploadImageAsync(BlogImage image, IFormFile file)
    {                                                                   //folder name   // file name
        var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

        using var Stream = new FileStream(localPath, FileMode.Create);
        await file.CopyToAsync(Stream);
        
        //localPath(Images/FileName.extension) is different from Url(https://url.com/localpath)
        //getting Url
        var httpRequest = httpContextAccessor.HttpContext!.Request;
        var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{image.FileName}{image.FileExtension}";

        //Assign Variables
        image.Url = urlPath;

        await dbContext.BlogImages.AddAsync(image);
        await dbContext.SaveChangesAsync();

        return image;
    }

    public async Task<bool> DeleteImageAsync(int Id)
    {
        var image = await dbContext.BlogImages.FirstOrDefaultAsync(i => i.Id == Id);
        
        if(image == null)
        {
            return false;
        }

        dbContext.BlogImages.Remove(image);
        await dbContext.SaveChangesAsync();
        return true;
    }
}

