using blazorHramPosts.Data;
using blazorHramPosts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramPosts.Services
{
    public interface ICommentsService
    {
        public IList<comment> comments(int postId);

        public ApplicationDbContext context();

        public void add(comment comment);
    }

    public class CommentsService : ICommentsService
    {
        ApplicationDbContext _context;
        public CommentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(comment comment)
        {
            if (comment!=null)
            {
                _context.comments.Add(comment);
                _context.SaveChangesAsync();
            }
        }

        public IList<comment> comments(int postId)
        {
            return _context.comments.Where(p => p.postID == postId).ToList();
        }

        public ApplicationDbContext context()
        {
            return _context;
        }
    }
}
