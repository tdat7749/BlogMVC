using Blog.Data.Configuration;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EF
{
    public class BlogDbContext : IdentityDbContext<UserApplication>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuration

            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new PostInTagConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; }
        public DbSet<Comment> Comments { get; }
        public DbSet<Post> Posts { get; }
        public DbSet<PostInTag> PostInTags {get; }
        public DbSet<Tag> Tags { get; }
        public DbSet<Carousel> Carousels { get; }
    }
}
