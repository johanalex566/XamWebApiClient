using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class ApiBookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public ApiBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetBooks()
        {
            var response = await _httpClient.GetAsync("GetProducts");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Product>>(responseAsString);
        }

        public async Task<Product> GetBook(int id)
        {
            var response = await _httpClient.GetAsync($"Products/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(responseAsString);
        }

        public async Task AddBook(Product book)
        {
            var response = await _httpClient.PostAsync("Products",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBook(Product book)
        {
            var response = await _httpClient.DeleteAsync($"Products/{book.Id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task SaveBook(Product book)
        {
            var response = await _httpClient.PutAsync($"Products?id={book.Id}",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
