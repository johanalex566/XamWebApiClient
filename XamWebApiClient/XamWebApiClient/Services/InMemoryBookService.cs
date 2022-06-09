using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class InMemoryBookService : IBookService
    {
        private readonly List<Product> _books = new List<Product>();
        public InMemoryBookService()
        {
            _books.Add(new Product { Id = 1, Name = "Clean code", ProductValue = 250, Description = "A book about good code" });
            _books.Add(new Product { Id = 2, Name = "The pragmatic programmer", ProductValue = 100, Description = "All about pragmatism" });
            _books.Add(new Product { Id = 3, Name = "Refactoring", ProductValue = 300, Description = "Working with legacy code" });
        }

        public Task AddBook(Product book)
        {
            book.Id = ++_books.Last().Id;
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBook(Product book)
        {
            _books.Remove(book);
            return Task.CompletedTask;
        }

        public Task<Product> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<IEnumerable<Product>> GetBooks()
        {
            return Task.FromResult( _books.AsEnumerable());
        }

        public Task SaveBook(Product book)
        {
            _books[_books.FindIndex(b => b.Id == book.Id)] = book;
            return Task.CompletedTask;
        }
    }
}
