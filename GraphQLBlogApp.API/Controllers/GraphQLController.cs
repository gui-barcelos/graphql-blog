//using System.Threading.Tasks;
//using GraphQL;
//using GraphQL.Types;
//using GraphQLBlogApp.API.GraphQL.Queries;
//using GraphQLBlogApp.Core.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace GraphQLBlogApp.API.Controllers
//{
//    [Route("graphql")]
//    public class GraphQLController : Controller
//    {
//        private readonly IPostRepository _postRepository;
//        public GraphQLController(IPostRepository postRepository)
//        {
//            _postRepository = postRepository;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
//        {
//            var schema = new Schema { Query = new PostQuery(_postRepository) };

//            var result = await new DocumentExecuter().ExecuteAsync(_ =>
//            {
//                _.Schema = schema;
//                _.Query = query.Query;

//            }).ConfigureAwait(false);

//            if (result.Errors?.Count > 0)
//            {
//                return BadRequest();
//            }

//            return Ok(result);
//        }
//    }
//}
