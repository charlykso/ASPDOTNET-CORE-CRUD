using System.Reflection.Emit;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.DataAccess
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}