using blazorHramPosts.Data;
using blazorHramPosts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramPosts.Services
{
    public interface IPostsService
    {
        Task<List<post>> posts();
        Task<post> post(int id);
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
                //context.tags.Add(new tag { text = "о храме" });
                //context.tags.Add(new tag { text = "о таинствах" });
                //context.posts.FirstOrDefault(p => p.ID == 32).tags.Add(context.tags.FirstOrDefault(t => t.text == "о таинствах"));
                //context.SaveChanges();

                return await context.posts.Include(p => p.comments).Include(p => p.likes).Include(p=>p.tags).ToListAsync();
            }
        }

        public async Task<post> post(int id)
        {
            using (var context = new ApplicationDbContext(options))
            {
                return await context.posts.Include(p => p.comments).Include(p => p.likes).FirstOrDefaultAsync(p=>p.ID==id);
            }
        }
    }
}
