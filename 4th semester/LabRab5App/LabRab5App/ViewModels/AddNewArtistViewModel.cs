using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Application.ArtistUseCase.Commands;

namespace LabRab5App.ViewModels
{
    [QueryProperty("Artist", "Artist")]
    [QueryProperty("Name", "Name")]
    [QueryProperty("Country", "Country")]
    [QueryProperty("birth", "birth")]
    [QueryProperty("Action","Action")]

    public partial class AddNewArtistViewModel: ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewArtistViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ObservableProperty]
        Artist artist;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string country;

        [ObservableProperty]
        DateTime birth;

        [RelayCommand]
        public async Task AddArtist()
        {
            if (name == string.Empty || country == string.Empty) return;
            await _mediator.Send(new AddArtistCommand(name, birth, country));
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
