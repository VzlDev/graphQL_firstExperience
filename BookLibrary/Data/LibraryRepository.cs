using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public interface ILibraryRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        Book AddBook(string title, int authorId);
        IEnumerable<Author> GetAuthors();

        Author GetAuthorById(int id);

        Author AddAuthor(Author author);
    }

    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks() => _context.Books.Include(b => b.Author).ToList();

        public Book GetBookById(int id) => _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);

        public Book AddBook(string title, int authorId)
        {
            var book = new Book { Title = title, AuthorId = authorId };
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public IEnumerable<Author> GetAuthors() => _context.Authors.Include(a => a.Books).ToList();

        public Author GetAuthorById(int id) => _context.Authors.Include(a => a.Books).FirstOrDefault(b => b.Id == id);

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }
    }
}
