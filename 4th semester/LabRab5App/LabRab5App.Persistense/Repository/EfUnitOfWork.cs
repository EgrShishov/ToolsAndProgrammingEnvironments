using LabRab5App.Persistence.Data;

namespace LabRab5App.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        protected readonly Lazy<IRepository<Artist>> _artistsRepository;
        protected readonly Lazy<IRepository<Song>> _songsRepository;
        public EfUnitOfWork(AppDbContext context) 
        {
            _context = context;
            _artistsRepository = new(() => new EfRepository<Artist>(_context));
            _songsRepository = new(() => new EfRepository<Song>(_context));
        }

        public IRepository<Song> SongsRepository => _songsRepository.Value;

        public IRepository<Artist> ArtistsRepository => _artistsRepository.Value;

        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();

        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();

        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
