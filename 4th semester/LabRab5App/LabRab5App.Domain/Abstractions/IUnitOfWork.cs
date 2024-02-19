using LabRab5App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab5App.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Song> SongsRepository { get; }
        IRepository<Artist> ArtistsRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
