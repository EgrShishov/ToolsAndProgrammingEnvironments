
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Pages;
using LabRab5App.Models;

namespace LabRab5App.ViewModels
{

    [QueryProperty("Song", "Song")]
    public partial class SongDetailsViewModel : ObservableObject
    {

        private readonly IMediator _mediator;
        public SongDetailsViewModel(IMediator mediator) => _mediator = mediator;

        [ObservableProperty]
        Song song;

        public async Task GoToEditSongPage(Song selectedSong)
        {
                IDictionary<string, object> parametrs = new Dictionary<string, object>()
            {
                {"Song", selectedSong }
            };
                await Shell.Current.GoToAsync(nameof(EditSongPage), parametrs);
        }

        [RelayCommand]
        public async Task ChangeSongInfo(Song selectedSong) => await GoToEditSongPage(selectedSong);
    }
}
