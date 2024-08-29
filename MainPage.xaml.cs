using LibraryApp_Maui.Models;
using LibraryApp_Maui.Services;
using LibraryApp_Maui.Pages;

namespace LibraryApp_Maui
{
    public partial class MainPage : ContentPage
    {
        public BookServices bookServices { get; set; }
        public List<Book> BooksList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            bookServices = new BookServices();
            BooksList = new List<Book>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            activityIndicator.IsRunning = true;
            BooksList = await bookServices.GetAllBooks();
            activityIndicator.IsRunning = false;
            if (BooksList != null)
            {
                booksCV.ItemsSource = BooksList.ToList();
            }
            booksCV.SelectedItem = null;
        }

        private async void addNewBookBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookAdd());
        }

        private async void editBookBtn_Clicked(object sender, EventArgs e)
        {
            if (BooksList.Count == 0)
            {
                return;
            }
            Book selectedBook = (Book)booksCV.SelectedItem;
            if (selectedBook != null)
            {
                await Navigation.PushAsync(new BookUpdate(selectedBook));
            }
            else
            {
                await DisplayAlert("Warning", "Please Select a Book First!", "OK");
            }
        }

        private async void deleteBookBtn_Clicked(object sender, EventArgs e)
        {
            if (BooksList.Count == 0)
            {
                return;
            }
            Book selectedBook = (Book)booksCV.SelectedItem;
            if (selectedBook != null)
            {
                bool displayAlertResult = await DisplayAlert("Warning", "Do you really want to delete this book?", "Yes", "No");
                if (displayAlertResult)
                {
                    bool deleteBookResult = await bookServices.DeleteBook(selectedBook);
                    booksCV.ItemsSource = await bookServices.GetAllBooks();
                    booksCV.SelectedItem = null;
                }
            }
            else
                await DisplayAlert("Warning", "Please Select a Book First!", "OK");
        }
    }

}
