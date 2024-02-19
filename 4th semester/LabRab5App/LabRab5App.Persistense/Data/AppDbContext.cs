using Microsoft.EntityFrameworkCore;

namespace LabRab5App.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContext _dbContext;
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
