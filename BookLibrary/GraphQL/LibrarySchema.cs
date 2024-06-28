using BookLibrary.GraphQL.Mutations;
using BookLibrary.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace BookLibrary.GraphQL
{
    public class LibrarySchema : Schema
    {
        public LibrarySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<LibraryQuery>();
            Mutation = provider.GetRequiredService<LibraryMutation>();
        }
    }
}
