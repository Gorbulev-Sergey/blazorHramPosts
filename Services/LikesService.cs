using blazorHramPosts.Data;
using blazorHramPosts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramPosts.Services
{
    public interface ILikesService
    {
        public IList<like> likes(int postId);
        public ApplicationDbContext context();
        public void add(like like);
        public void delete(int likeID);
    }

    public class LikesService : ILikesService
    {
        ApplicationDbContext _context;
        public LikesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(like like)
        {
            if (like != null)
            {
                _context.likes.Add(like);
                _context.SaveChanges();
            }            
        }

        public ApplicationDbContext context()
        {
            return _context;
        }

        public void delete(int likeID)
        {
            _context.likes.Remove(_context.likes.FirstOrDefault(like=>like.ID==likeID));
            _context.SaveChanges();
        }

        public IList<like> likes(int postId)
        {
            return _context.likes.Where(l => l.postID == postId).ToList();
        }
    }
}
