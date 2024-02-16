namespace MyMauiApp;

using Microsoft.Maui.Controls;
using MyMauiApp.Entities;
using MyMauiApp.Services;

public partial class BookPage : ContentPage
{
	private IDbService dbService;
	public BookPage(IDbService service)
	{
		InitializeComponent();

		dbService = service;
		BindingContext = this;
    }

	private void OnPageLoaded(object sender, EventArgs e)
	{
		List<Author> itemsSource = new List<Author>();
		foreach(var item in dbService.GetAllAuthors())
		{
			itemsSource.Add(item);
		}
		AuthorPicker.ItemsSource = itemsSource;
	}

	private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if(selectedIndex != -1)
		{
			var books = dbService.GetBooksByAuthor(selectedIndex+1);

			collectionView.Header = "Все книги";
			collectionView.ItemsSource = books;
		}
	}
}