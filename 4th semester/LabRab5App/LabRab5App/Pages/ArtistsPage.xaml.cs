using LabRab5App.ViewModels;
namespace LabRab5App.Pages;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(ArtistsViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        foreach (var item in MenuBarItems)
        {
            item.BindingContext = BindingContext;
        }
    }
}