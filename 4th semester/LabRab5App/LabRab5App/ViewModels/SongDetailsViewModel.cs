
using CommunityToolkit.Mvvm.ComponentModel;

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
    }
}
