using Microsoft.EntityFrameworkCore;
using PTBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Infrastructure.Data
{
    internal class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            
        }

        internal DbSet<BlogPost> BlogPosts { get; set; }
        internal DbSet<BlogPostCategory> BlogPostCategories { get; set; }
        internal DbSet<BlogImage> BlogImages { get; set; }
        internal DbSet<Category> Categories { get; set; }
        
    }
}
