
using PTBlog.Domain.Entities;

namespace PTBlog.Domain.Repositories
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost Post);
        Task<List<BlogPost>?> GetAllAsync(string? filter = null, string sortBy = "DateCreated", string? sortDir = "asc", int pageNumber = 1, int pageSize = 10);

        Task<BlogPost?> GetByUrlHandle(string urlHandle);
        Task<BlogPost?> GetAsync(Guid Id, bool isTracking = false);

        Task UpdateAsync(BlogPost post);

        Task DeleteAsync(BlogPost post);

        Task<int> GetBlogpostsCount(string? filter = null);
    }
}
