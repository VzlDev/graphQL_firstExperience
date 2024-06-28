using BookLibrary.Models;
using GraphQL.Types;

namespace BookLibrary.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field<AuthorType>("author", resolve: context => context.Source.Author);
        }
    }
}
