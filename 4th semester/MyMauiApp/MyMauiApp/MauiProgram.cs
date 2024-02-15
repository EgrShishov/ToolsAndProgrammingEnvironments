using Microsoft.Extensions.Logging;
using MyMauiApp.Pages;
using MyMauiApp.Services;

namespace MyMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<IDbService, SQLiteService>();
			builder.Services.AddSingleton<BookPage>();
		builder.Services.AddTransient<IRateService, RateService>();
			builder.Services.AddSingleton<CurrencyConverterPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
