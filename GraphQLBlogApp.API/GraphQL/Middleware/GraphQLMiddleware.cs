﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLBlogApp.API.GraphQL.Queries;
using GraphQLBlogApp.Core.Data;
using Microsoft.AspNetCore.Http;

namespace GraphQLBlogApp.API.GraphQL.Middleware
{
    public class GraphQlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPostRepository _postRepository;

        public GraphQlMiddleware(RequestDelegate next, IPostRepository postRepository)
        {
            _next = next;
            _postRepository = postRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var sent = false;
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var sr = new StreamReader(httpContext.Request.Body))
                {
                    var query = await sr.ReadToEndAsync();

                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema { Query = new PostQuery(_postRepository) };
                        var result = await new DocumentExecuter()
                          .ExecuteAsync(options =>
                          {
                              options.Schema = schema;
                              options.Query = query;
                          }).ConfigureAwait(false);
                        CheckForErrors(result);
                        await WriteResult(httpContext, result);
                        sent = true;
                    }
                }
            }
            if (!sent)
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }

        private void CheckForErrors(ExecutionResult result)
        {
            if (result.Errors?.Count > 0)
            {
                var errors = new List<Exception>();
                foreach (var error in result.Errors)
                {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
    }
}
