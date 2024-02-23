using LabRab5App.ViewModels;

namespace LabRab5App.Pages;

public partial class AddNewSongPage : ContentPage
{
	public AddNewSongPage(AddNewSongViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}