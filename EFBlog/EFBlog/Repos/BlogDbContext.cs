using EFBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFBlog
{
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) {}

    }
}
