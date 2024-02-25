using LabRab5App.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;
using System.Linq.Expressions;

namespace LabRab5App.Persistence.Repository
{
    public class FakeSongsRepository : IRepository<Song>
    {
        List<Song> _songs;
        public FakeSongsRepository() 
        { 
            _songs = new List<Song>();

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

        }
        public Task AddAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Song>> GetAllValuesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Song> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetFirstOrDefaultAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Song>> GetListAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
        {
            var query = _songs.AsQueryable();
            Debug.WriteLine(_songs.Count);
            return await Task.Run(() => query.Where(filter).ToList() as IReadOnlyList<Song>);
        }

        public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
