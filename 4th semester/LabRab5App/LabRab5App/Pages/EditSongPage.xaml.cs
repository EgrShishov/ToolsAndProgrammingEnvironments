using LabRab5App.ViewModels;

namespace LabRab5App.Pages;

public partial class EditSongPage : ContentPage
{
	public EditSongPage(ChangeSongViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;	
	}
}