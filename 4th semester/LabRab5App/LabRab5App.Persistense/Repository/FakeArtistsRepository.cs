using LabRab5App.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LabRab5App.Persistence.Repository
{
    public class FakeArtistsRepository : IRepository<Artist>
    {
        List<Artist> _artists;
        public FakeArtistsRepository() 
        {
            _artists = new List<Artist>();

            var artist = new Artist("Michael Jackson", DateTime.Now, "USA");
            artist.Id = 1;
            _artists.Add(artist);

            artist = new Artist("Adel", DateTime.Now.AddYears(-10), "UK");
            artist.Id = 2;
            _artists.Add(artist);

            artist = new Artist("Zemphira", DateTime.Now.AddYears(-5).AddDays(-145), "Russia");
            artist.Id = 3;
            _artists.Add(artist);
        }

        public Task AddAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Artist>> GetAllValuesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _artists);
        }

        public Task<Artist> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Artist, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetFirstOrDefaultAsync(Expression<Func<Artist, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Artist>> GetListAsync(Expression<Func<Artist, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Artist, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
