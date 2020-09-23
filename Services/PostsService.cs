using blazorHramPosts.Data;
using blazorHramPosts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace blazorHramPosts.Services
{
    public interface IPostsService
    {
        public IList<post> get();
        public ApplicationDbContext context { get; }
    }

    public class PostsServices : IPostsService
    {
        ApplicationDbContext _context;
        public PostsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext context {
            get { return _context; }
        }

        public IList<post> get()
        {
            return _context.posts.ToList();
        }
    }
}
