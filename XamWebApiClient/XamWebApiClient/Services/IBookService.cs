using System.Collections.Generic;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Product>> GetBooks();
        Task<Product> GetBook(int id);
        Task AddBook(Product book);
        Task SaveBook(Product book);
        Task DeleteBook(Product book);      
    }
}
