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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
        public DbSet<schedule_string> schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Настройка связи многие - ко - многим для post-tag
            modelBuilder.Entity<posttag>()
            .HasKey(t => new { t.postsID, t.tagsID });

            modelBuilder.Entity<posttag>()
                .HasOne(pt => pt.post)
                .WithMany(p => p.posttags)
                .HasForeignKey(pt => pt.postsID);

            modelBuilder.Entity<posttag>()
                .HasOne(pt => pt.tag)
                .WithMany(t => t.posttags)
                .HasForeignKey(pt => pt.tagsID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
