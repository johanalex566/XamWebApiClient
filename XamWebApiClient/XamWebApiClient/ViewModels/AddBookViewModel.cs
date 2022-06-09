using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private readonly IBookService _bookService;
        private string name;
        private decimal productValue;
        private string description;

        public AddBookViewModel(IBookService bookService)
        {
            _bookService = bookService;

            SaveBookCommand = new Command(async () => await SaveBook());
        }

        private async Task SaveBook()
        {
            try
            {
                var book = new Book
                {
                    Name = Name,
                    ProductValue = ProductValue,
                    Description = Description
                };

                await _bookService.AddBook(book);              

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
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
