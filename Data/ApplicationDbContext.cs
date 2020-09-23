using System;
using System.Collections.Generic;
using System.Text;
using blazorHramPosts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blazorHramPosts.Data
{
    public class ApplicationDbContext : IdentityDbContext<user>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            posts = Set<post>();
            comments = Set<comment>();
            likes = Set<like>();
            imageAlbums = Set<imageAlbum>();
        }
        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
    }
}
