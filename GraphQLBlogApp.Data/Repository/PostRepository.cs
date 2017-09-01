using System.Collections.Generic;
using System.Linq;
using GraphQLBlogApp.Core.Data;
using GraphQLBlogApp.Core.Models;
using GraphQLBlogApp.Data.Infra;

namespace GraphQLBlogApp.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly GraphQLBlogDbContext _db;
        public PostRepository(GraphQLBlogDbContext db)
        {
            _db = db;
        }

        public List<Post> FindByContent(string content)
        {
            return _db.Post.Where(x => x.Content.ToUpper().Contains(content.ToUpper())).ToList();
        }

        public List<Post> List()
        {
            return _db.Post.ToList();
        }
    }
}
