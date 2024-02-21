
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Application.ArtistUseCase.Queries;
using LabRab5App.Application.SongUseCase.Queries;
using LabRab5App.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LabRab5App.ViewModels
{
    public partial class ArtistsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public ObservableCollection<Artist> Artists { get ; set; } = new();
        public ObservableCollection<Song> Songs { get; set; } = new();

        public ArtistsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        Artist selectedArtist;

        public async Task SetArtists(CancellationToken cancellationToken = default)
        {
            var artists = await _mediator.Send(new GetArtistsByGroupRequest());
            Trace.WriteLine($"{artists.Count()}");
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Artists.Clear();
                foreach (var artist in artists)
                {
                    Artists.Add(artist);
                }
            });
        }

        public async Task SetSongs(CancellationToken cancellationToken = default)
        {
            var songs = await _mediator.Send(new GetSongsByGroupRequest(selectedArtist.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach(var song in songs)
                {
                    Songs.Add(song);
                }
            });
        }

        private async Task GoToDetailsPage(Song song, CancellationToken cancellationToken = default)
        {
            IDictionary<string, object> parametrs = new Dictionary<string, object>()
            {
                {"Song", song}
            };
            await Shell.Current.GoToAsync(nameof(SongDetails));
        }

/*        private async Task GoBackwards(CancellationToken cancellationToken = default)
        {
            await Shell.Current.GoToAsync("..");
        }*/

        [RelayCommand]
        public async Task UpdateGroupList() => await SetArtists();

        [RelayCommand]
        public async Task UpdateMembersList() => await SetSongs();

        [RelayCommand]
        public async Task ShowDetails(Song song) => await GoToDetailsPage(song);
        //[RelayCommand]
        //public async void GoBack() => await GoBackwards();
    }
}
