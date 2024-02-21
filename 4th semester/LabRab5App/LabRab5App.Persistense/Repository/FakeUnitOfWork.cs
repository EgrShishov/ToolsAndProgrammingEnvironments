

using LabRab5App.Persistence.Data;

namespace LabRab5App.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Artist>> _artists;
        private readonly Lazy<IRepository<Song>> _songs;
        public FakeUnitOfWork(AppDbContext context) 
        {
            _context = context;
            _artists = new(() => new FakeArtistsRepository(context));
            _songs = new(() => new FakeSongsRepository(context));
        }

        public IRepository<Song> SongsRepository => _songs.Value;

        public IRepository<Artist> ArtistsRepository => _artists.Value;

        public async Task CreateDataBaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataBaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
