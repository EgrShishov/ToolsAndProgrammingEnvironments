using LabRab5App.Pages;

namespace LabRab5App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SongDetails), typeof(SongDetails));
            Routing.RegisterRoute(nameof(AddNewArtistPage), typeof(AddNewArtistPage));
            Routing.RegisterRoute(nameof(AddNewSongPage), typeof(AddNewSongPage));
        }
    }
}
