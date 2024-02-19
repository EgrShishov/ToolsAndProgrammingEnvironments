using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Title { get; private set; }

        public int ChartPosition { get; private set;}

        public double Length { get; private set; }

        public string Genre { get; private set;}

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
    }
}
