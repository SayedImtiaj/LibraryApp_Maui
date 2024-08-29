using LibraryApp_Maui.Models;
using LibraryApp_Maui.Services;

namespace LibraryApp_Maui.Pages;

public partial class BookAdd : ContentPage
{
    public BookServices bookServices { get; set; }
    public CategoryServices categoryServices { get; set; }

    public BookAdd()
	{
		InitializeComponent();
        bookServices = new BookServices();
        categoryServices = new CategoryServices();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Category> categoryList = await categoryServices.GetAllCategories();
        if (categoryList != null)
        {
            categoryPicker.ItemsSource = categoryList.ToList();
        }
    }

    private async void saveBookBtn_Clicked(object sender, EventArgs e)
    {
        Category selectedCategory = (Category)categoryPicker.SelectedItem;
        Book bookInfo = new Book();
        bookInfo.BookName = bookName.Text;
        bookInfo.CategoryId = selectedCategory.CategoryId;
        bookInfo.Description = description.Text;
        bookInfo.Edition = edition.Text;
        Book addBookResult = await bookServices.AddNewBook(bookInfo);
        await Navigation.PopAsync();
    }
}