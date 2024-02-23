using LabRab5App.ViewModels;
namespace LabRab5App.Pages;

public partial class AddNewArtistPage : ContentPage
{
	public AddNewArtistPage(AddNewArtistViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}