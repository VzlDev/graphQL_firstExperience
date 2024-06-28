using BookLibrary.Data;
using BookLibrary.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace BookLibrary.GraphQL.Queries
{
    public class LibraryQuery : ObjectGraphType
    {
        public LibraryQuery(ILibraryRepository repository)
        {
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => repository.GetBooks());

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => repository.GetBookById(context.GetArgument<int>("id")));

            Field<ListGraphType<AuthorType>>(
                "authors",
                resolve: context => repository.GetAuthors());

            Field<AuthorType>(
                "author",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => repository.GetAuthorById(context.GetArgument<int>("id")));
        }
    }
}
