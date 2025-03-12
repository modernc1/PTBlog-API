using Microsoft.EntityFrameworkCore;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using PTBlog.Infrastructure.Data;

namespace PTBlog.Infrastructure.Repositories;

internal class CategoryRepository(BlogDbContext context) : ICategoryRepository
{
    public async Task CreateAsync(Category category)
    {
        await context.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid Id)
    {
        var post = await context.Categories.FirstOrDefaultAsync(p => p.Id == Id) ?? throw new Exception("category not found");

        context.Remove(post);
        await context.SaveChangesAsync();

    }

    public async Task<Category?> GetAsync(Guid Id, bool isTracking = false)
    {
        Category? post;

        if(isTracking)
        {
            post = await context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
        }
        else
        {
            post = await context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
        }
        return post;
    }

    public async Task<List<Category>> GetAllAsync(string? filter = null, string sortBy = "name", string sortDirection = "asc")
    {
        //query
        var query = context.Categories.AsQueryable();
        
        //filtering
        if(filter != null)
        {
            query = query.Where(x => x.Name.Contains(filter)); //contains ignore case by default
        }
        
        //sorting
        if(string.Equals(sortBy, "name", StringComparison.OrdinalIgnoreCase))
        {
            var isAsc = string.Equals(sortDirection, "asc", StringComparison.OrdinalIgnoreCase) ? true : false;

            query = isAsc ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
        }
        
        //pagination



        return await query.ToListAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }
}
