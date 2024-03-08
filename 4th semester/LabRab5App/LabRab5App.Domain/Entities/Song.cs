
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

        public void ChangeChartPosition(int newPosition)
        {
            if (newPosition <= 0) return;
            ChartPosition = newPosition;
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void ChangeGenre(string newGenre)
        {
            Genre = newGenre;
        }

        public void ChangeLength(double newLength)
        {
            Length = newLength;
        }
    }
}
