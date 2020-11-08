using blazorHramPosts.Data;
using blazorHramPosts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorHramPosts.Services
{
    public interface IPostsService
    {
        Task<List<post>> posts();
    }

    public class PostsServices : IPostsService
    {
        DbContextOptions<ApplicationDbContext> options;
        public PostsServices(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
        public async Task<List<post>> posts()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return await context.posts.Include(p => p.comments).Include(p => p.likes).ToListAsync();
            }
        }
    }
}
