using GraphQLBlogApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBlogApp.Data.Infra
{
    public class GraphQLBlogDbContext : DbContext
    {
        public GraphQLBlogDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(x => x.Id).UseSqlServerIdentityColumn();
        }
    }
}
