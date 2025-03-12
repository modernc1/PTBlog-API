
using PTBlog.Domain.Entities;

namespace PTBlog.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<List<Category>> GetAllAsync(string? filter = null, string sortBy = "name", string sortDirection = "asc");

        Task<Category?> GetAsync(Guid Id, bool isTracking = false);

        Task UpdateAsync(Category post);

        Task DeleteAsync(Guid Id);
    }
}
