using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LabRab5App.ViewModels
{
    [QueryProperty("SongToAdd",nameof(Song))]
    [QueryProperty("Artist", nameof(Artist))]
    public partial class AddNewSongViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddNewSongViewModel(IMediator mediator) => _mediator = mediator;

        [ObservableProperty]
        Song newSong;
        [ObservableProperty]
        Artist selectedArtist;

        [RelayCommand]
        public async Task AddSong()
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
