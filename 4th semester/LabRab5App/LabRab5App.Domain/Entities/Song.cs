
namespace LabRab5App.Domain.Entities
{
    public class Song : Entity
    {
        private Song() { }

        public Song(string title, int chartPosition, string genre, double? length = 0)
        {
            Title = title;
            ChartPosition = chartPosition;
            Length = length.Value;
            Genre = genre;
        }

        public string Title { get; set; }

        public int ChartPosition { get; set;}

        public double Length { get; set; }

        public string Genre { get; set;}

        public int? ArtistId {  get; private set; }

        public void AddToArtist(int artistId)
        {
            if (artistId <= 0) return;
            ArtistId = artistId;
        }

        public void DeleteFromArtist()
        {
            ArtistId = 0;
        }

        public void ChangeSong(Song changedSong)
        {
            if (changedSong.ChartPosition < 0 || changedSong.Length < 0 
                || changedSong.Genre == string.Empty || changedSong.Title == string.Empty) return;

            Title = changedSong.Title;
            Genre = changedSong.Genre;
            Length = changedSong.Length;
            ChartPosition = changedSong.ChartPosition;
        }
    }
}
