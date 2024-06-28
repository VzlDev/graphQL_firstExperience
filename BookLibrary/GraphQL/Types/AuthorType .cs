using BookLibrary.Models;
using GraphQL.Types;

namespace BookLibrary.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<ListGraphType<BookType>>("books", resolve: context => context.Source.Books);
        }
    }
}
