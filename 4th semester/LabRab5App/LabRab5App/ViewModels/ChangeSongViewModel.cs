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
            await _mediator.Send(new ChangeSongsInfoCommand(song));
            await Shell.Current.GoToAsync("../..");
        }

        [RelayCommand]
        public async Task ChangeGroup()
        {
            if (selectedIndex == -1) return;
            song.DeleteFromArtist();
            song.AddToArtist(selectedIndex + 1);
            await _mediator.Send(new ChangeSongsInfoCommand(song));
            await Shell.Current.GoToAsync("../..");
        }

    }
}
