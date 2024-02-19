using LabRab5App.Persistence.Data;
using LabRab5App.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LabRab5App.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence()
                .AddSingleton<AppDbContext>(new AppDbContext((DbContextOptions<AppDbContext>)(options)));
            return services;
        }
    }
}
