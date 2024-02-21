
using LabRab5App.Pages;
using LabRab5App.ViewModels;

namespace LabRab5App
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<ArtistsPage>()
                    .AddTransient<SongDetails>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<ArtistsViewModel>()
                    .AddTransient<SongDetailsViewModel>();
            return services;
        }
    }
}
