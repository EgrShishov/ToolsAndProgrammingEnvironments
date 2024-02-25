
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LabRab5App.ViewModels
{
    [QueryProperty("Song", "Song")]
    public partial class SongDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public SongDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        Song song;

        public async Task<Song> ChangeSong()
        {
            return song;
        }

        public async Task<Song> ChangeSongsArtist()
        {
            return song;
        }

        public async Task PickImage()
        {
            return;
        }

        [RelayCommand]
        public async Task ChangeSongInfo() => await ChangeSong();

        [RelayCommand]
        public async Task TransferToAnotherArtist() => await ChangeSongsArtist();

        [RelayCommand]
        public async Task PickSongsImage() => await PickImage();
    }
}
