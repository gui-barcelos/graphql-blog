# GraphQL + EFCore Demo App

Using postman, make a post to http://localhost:52740/ with body below: 
```
{
  posts(content: ".net") { id, title, content }
}
```