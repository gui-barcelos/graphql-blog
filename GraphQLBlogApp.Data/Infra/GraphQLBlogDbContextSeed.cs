using System.Linq;
using GraphQLBlogApp.Core.Models;

namespace GraphQLBlogApp.Data.Infra
{
    public static class GraphQLBlogDbContextSeed
    {
        public static void Seed(this GraphQLBlogDbContext db)
        {
            if (!db.Post.Any())
            {
                db.Post.Add(new Post() { Title = "About .NET", Content = "Post talking about .NET stack." });
                db.Post.Add(new Post() { Title = "About JavaScript", Content = "Post talking about JavaScript stack." });

                db.SaveChanges();
            }
        }
    }
}
