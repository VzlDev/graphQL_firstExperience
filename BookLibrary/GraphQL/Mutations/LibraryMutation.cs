using BookLibrary.Data;
using BookLibrary.GraphQL.Types;
using BookLibrary.Models;
using GraphQL;
using GraphQL.Types;

namespace BookLibrary.GraphQL.Mutations
{
    public class LibraryMutation : ObjectGraphType
    {
        public LibraryMutation(ILibraryRepository repository)
        {
            Field<BookType>(
                "addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "authorId" }),
                resolve: context =>
                {
                    var title = context.GetArgument<string>("title");
                    var authorId = context.GetArgument<int>("authorId");
                    return repository.AddBook(title, authorId);
                });

            Field<AuthorType>(
                "addAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    var author = new Author
                    {
                        Name = name,
                        Books = new List<Book>() // Initialize books list as needed
                    };
                    return repository.AddAuthor(author);
                });
        }
    }
}
