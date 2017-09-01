using GraphQL.Types;
using GraphQLBlogApp.API.GraphQL.Types;
using GraphQLBlogApp.Core.Data;

namespace GraphQLBlogApp.API.GraphQL.Queries
{
    public class PostQuery : ObjectGraphType
    {
        public PostQuery(IPostRepository postRepository)
        {
            Field<ListGraphType<PostType>>("posts",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>() { Name = "content" }),
                resolve: context =>
                {
                    var content = context.GetArgument<string>("content");
                    if (string.IsNullOrWhiteSpace(content))
                        return postRepository.List();
                    else
                        return postRepository.FindByContent(content);
                });
        }
    }
}
