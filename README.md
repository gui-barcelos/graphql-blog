# GraphQL Blog
Simple Blog app using GraphQL, .NET Core and EF Core.

Using postman, make a post to http://localhost:52740/ with body below: 
```
{
  posts(content: ".net") { id, title, content }
}
```

Todo list:
- [x] Initial structure
- [ ] Integration Test for testing
- [ ] UI