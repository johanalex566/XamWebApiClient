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
        private string author;
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
                    Author = Author,
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
        public string Author
        {
            get => author; 
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
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
