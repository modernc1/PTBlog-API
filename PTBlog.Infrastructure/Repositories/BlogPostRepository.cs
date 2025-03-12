

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using PTBlog.Infrastructure.Data;
using System.Linq.Expressions;

namespace PTBlog.Infrastructure.Repositories;

internal class BlogPostRepository(BlogDbContext context) : IBlogPostRepository
{
    public async Task<BlogPost> CreateAsync(BlogPost Post)
    {
        await context.AddAsync(Post);
        await context.SaveChangesAsync();
        return Post;
    }

    public async Task DeleteAsync(BlogPost post)
    {

        context.Remove(post);
        await context.SaveChangesAsync();

    }

    public async Task<BlogPost?> GetAsync(Guid Id, bool isTracking = false)
    {
        BlogPost? post;

        if (isTracking)
        {
            post = await context.BlogPosts.Include(c => c.Categories).ThenInclude(c => c.Category).FirstOrDefaultAsync(p => p.Id == Id);
        }
        else
        {
            post = await context.BlogPosts.Include(c => c.Categories).ThenInclude(c => c.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
        }
         

        return post;
    }


    

    public async Task<List<BlogPost>?> GetAllAsync(string? filter = null, string sortBy = "DateCreated", string? sortDir = "asc", int pageNumber = 1, int pageSize = 10)
    {
        var query = context.BlogPosts.AsQueryable();

        //filtering
        if (filter != null)
        {
            query = query.Where(x => x.Title.Contains(filter)); //contains ignore case by default
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            query = _ApplySorting(query, sortBy, sortDir?.ToLower() == "asc");
        }


        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        

        return await query.Include(c => c.Categories).ThenInclude(c => c.Category).ToListAsync();
    }

    public async Task<int> GetBlogpostsCount(string? filter = null)
    {
        int count = 0;
        if (!string.IsNullOrEmpty(filter))
        {
            count = await context.BlogPosts.Where(x => x.Title.Contains(filter)).CountAsync();
        }
        else
        {
            count = await context.BlogPosts.CountAsync();
        }

        return count;
    }


    private IQueryable<T> _ApplySorting<T>(IQueryable<T> query, string sortBy, bool ascending)
    {
        var parameter = Expression.Parameter(typeof(T), "x"); // parameter in (x => x. ...);
        var property = Expression.PropertyOrField(parameter, sortBy); // like property (DateCreated) in this ex (x => x.DateCreated)
        var lambda = Expression.Lambda(property, parameter); // the actual lambda (x => x.Property)

        string methodName = ascending ? "OrderBy" : "OrderByDescending"; // the method name that we want to put lambda in it

        return query.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            )
        );
    }

    public async Task UpdateAsync(BlogPost post)
    {
        var categories = context.BlogPostCategories.Where(c => c.BlogPostId == post.Id).ToList();
        if (categories.Count != 0)
        {
            context.BlogPostCategories.RemoveRange(categories);
        }
        context.BlogPosts.Update(post);
        await context.SaveChangesAsync();
    }

    public async Task<BlogPost?> GetByUrlHandle(string urlHandle)
    {
        var blogPost = await context.BlogPosts.Include(c => c.Categories).ThenInclude(c => c.Category).FirstOrDefaultAsync(c => c.UrlHandle == urlHandle);

        return blogPost;
    }
}
