using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Application.ArtistUseCase.Commands;

namespace LabRab5App.ViewModels
{
    [QueryProperty("ArtistToAdd", nameof(Artist))]
    public partial class AddNewArtistViewModel: ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewArtistViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        Artist newArtist;

        [RelayCommand]
        public async void AddArtist()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
