using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class InMemoryBookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        public InMemoryBookService()
        {
            _books.Add(new Book { Id = 1, Name = "Clean code", ProductValue = 250, Description = "A book about good code" });
            _books.Add(new Book { Id = 2, Name = "The pragmatic programmer", ProductValue = 100, Description = "All about pragmatism" });
            _books.Add(new Book { Id = 3, Name = "Refactoring", ProductValue = 300, Description = "Working with legacy code" });
        }

        public Task AddBook(Book book)
        {
            book.Id = ++_books.Last().Id;
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBook(Book book)
        {
            _books.Remove(book);
            return Task.CompletedTask;
        }

        public Task<Book> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            return Task.FromResult( _books.AsEnumerable());
        }

        public Task SaveBook(Book book)
        {
            _books[_books.FindIndex(b => b.Id == book.Id)] = book;
            return Task.CompletedTask;
        }
    }
}
