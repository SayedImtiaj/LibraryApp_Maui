using LibraryApp_Maui.Models;
using LibraryApp_Maui.Services;

namespace LibraryApp_Maui.Pages;

public partial class BookUpdate : ContentPage
{
    public BookServices bookServices { get; set; }
    public CategoryServices categoryServices { get; set; }
    public Book SelectedBook { get; set; }

    public BookUpdate(Book _selectedBook)
	{
		InitializeComponent();
        bookServices = new BookServices();
        categoryServices = new CategoryServices();
        SelectedBook = _selectedBook;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Category> categoryList = await categoryServices.GetAllCategories();
        categoryPicker.ItemsSource = categoryList.ToList();
        bookName.Text = SelectedBook.BookName;
        categoryPicker.SelectedItem = categoryList.First(category => category.CategoryId == SelectedBook.CategoryId);
        description.Text = SelectedBook.Description;
        edition.Text = SelectedBook.Edition;
    }

    private async void saveChangesBtn_Clicked(object sender, EventArgs e)
    {
        Category selectedCategory = (Category)categoryPicker.SelectedItem;
        SelectedBook.BookName = bookName.Text;
        SelectedBook.CategoryId = selectedCategory.CategoryId;
        Book editBookResult = await bookServices.EditBook(SelectedBook);
        await Navigation.PopAsync();
    }
}