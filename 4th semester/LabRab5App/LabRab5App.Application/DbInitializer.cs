
namespace LabRab5App.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            //add artists
            var _artists = new List<Artist>();

            var artist = new Artist("Michael Jackson", DateTime.Now, "USA");
            artist.Id = 1;
            _artists.Add(artist);

            artist = new Artist("Adel", DateTime.Now.AddYears(-10), "UK");
            artist.Id = 2;
            _artists.Add(artist);

            artist = new Artist("Zemphira", DateTime.Now.AddYears(-5).AddDays(-145), "Russia");
            artist.Id = 3;
            _artists.Add(artist);

            foreach(var Artist in _artists)
            {
                await unitOfWork.ArtistsRepository.AddAsync(Artist);
            }
            await unitOfWork.SaveAllAsync();

            //add songs
            var _songs = new List<Song>();
            //Adel
            var song = new Song("Skyfall", 12, "Pop", 2.53);
            song.AddToArtist(2);
            _songs.Add(song);

            song = new Song("Hello", 56, "Pop", 3.45);
            song.AddToArtist(2);
            _songs.Add(song);

            song = new Song("Someone like you", 120, "Pop", 2.12);
            song.AddToArtist(2);
            _songs.Add(song);

            song = new Song("Send my love", 1, "Pop", 3.49);
            song.AddToArtist(2);
            _songs.Add(song);

            song = new Song("Set fire to the rain", 53, "Pop", 3.45);
            song.AddToArtist(2);
            _songs.Add(song);

            //Jackson
            song = new Song("Billie Jean", 1, "Pop", 2.53);
            song.AddToArtist(1);
            _songs.Add(song);

            song = new Song("Smooth Criminal", 1, "Pop", 3.45);
            song.AddToArtist(1);
            _songs.Add(song);

            song = new Song("Beat It", 1, "Pop", 2.12);
            song.AddToArtist(1);
            _songs.Add(song);

            song = new Song("Bad", 2, "Pop", 3.56);
            song.AddToArtist(1);
            _songs.Add(song);

            song = new Song("Chicago", 120, "Pop", 1.59);
            song.AddToArtist(1);
            _songs.Add(song);

            //Zemphira
            song = new Song("П.М.Л.М.", 10, "Rock", 2.00);
            song.AddToArtist(3);
            _songs.Add(song);

            song = new Song("Хочешь?", 18, "Рок", 3.02);
            song.AddToArtist(3);
            _songs.Add(song);

            song = new Song("Искала", 1, "Рок", 2.12);
            song.AddToArtist(3);
            _songs.Add(song);

            song = new Song("Ромашки", 2, "Рок", 3.56);
            song.AddToArtist(3);
            _songs.Add(song);

            song = new Song("Снег", 120, "Рок", 1.59);
            song.AddToArtist(3);
            _songs.Add(song);

            foreach(var Song in _songs)
            {
                await unitOfWork.SongsRepository.AddAsync(Song);
            }
            await unitOfWork.SaveAllAsync();
        }
    }
}
