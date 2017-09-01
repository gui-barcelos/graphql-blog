using GraphQL.Types;
using GraphQLBlogApp.Core.Models;

namespace GraphQLBlogApp.API.GraphQL.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Content);
        }
    }
}
