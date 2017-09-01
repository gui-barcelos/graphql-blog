using System.Collections.Generic;
using GraphQLBlogApp.Core.Models;

namespace GraphQLBlogApp.Core.Data
{
    public interface IPostRepository
    {
        List<Post> FindByContent(string content);
        List<Post> List();
    }
}
