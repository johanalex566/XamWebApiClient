using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailsViewModel : BaseViewModel
    {
        private string bookId;
        private string title;
        private decimal productValue;
        private string description;
        private readonly IBookService _bookService;

        public BookDetailsViewModel(IBookService bookService)
        {
            _bookService = bookService;

            SaveBookCommand = new Command(async () => await SaveBook());
        }

        private async Task SaveBook()
        {
            try
            {
                var book = new Product
                {
                    Id = int.Parse(BookId),
                    Name = Name,
                    ProductValue = ProductValue,
                    Description = Description
                };

                await _bookService.SaveBook(book);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadBook(string bookId)
        {
            try
            {
                var book = await _bookService.GetBook(int.Parse(bookId));
                if(bookId != null)
                {
                    Name = book.Name;
                    ProductValue = book.ProductValue;
                    Description = book.Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string BookId
        {
            get => bookId; 
            set
            {
                bookId = value;
                LoadBook(bookId);
            }
        }

        public string Name
        {
            get => title; 
            set
            {
                title = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public decimal ProductValue
        {
            get => productValue; 
            set
            {
                productValue = value;
                OnPropertyChanged(nameof(ProductValue));
            }
        }
        public string Description
        {
            get => description; 
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SaveBookCommand { get; }
    }
}
