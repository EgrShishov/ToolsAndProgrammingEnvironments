using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Application.ArtistUseCase.Queries;
using LabRab5App.Application.SongUseCase.Commands;
using System.Collections.ObjectModel;

namespace LabRab5App.ViewModels
{
    [QueryProperty("Song","Song")]
    public partial class ChangeSongViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public ObservableCollection<Artist> Artists { get; set; } = new();
        public ChangeSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        Song song;
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string genre;
        [ObservableProperty]
        double length;
        [ObservableProperty]
        int chartPosition;
        [ObservableProperty]
        int selectedIndex;

        public async Task SetArtists(CancellationToken cancellationToken = default)
        {
            var artists = await _mediator.Send(new GetArtistsByGroupRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Artists.Clear();
                foreach (var artist in artists)
                {
                    Artists.Add(artist);
                }
                Title = Song.Title;
                Genre = Song.Genre;
                Length = Song.Length;
                ChartPosition = Song.ChartPosition;
            });
        }

        [RelayCommand]
        public async void SetPickerSources() => await SetArtists();

        [RelayCommand]
        public async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async void EditSong()
        {
            Song.ChangeSong(new Song(Title, ChartPosition, Genre, Length));
            await _mediator.Send(new ChangeSongsInfoCommand(Song));
            await Shell.Current.GoToAsync("../..", true);
        }

        [RelayCommand]
        public async Task ChangeGroup()
        {
            if (SelectedIndex == -1) return;
            Song.DeleteFromArtist();
            Song.AddToArtist(SelectedIndex + 1);
            await _mediator.Send(new ChangeSongsInfoCommand(Song));
            await Shell.Current.GoToAsync("../..");
        }
          
    }
}
