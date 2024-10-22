﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using LabRab5App.Application;
using LabRab5App.Persistence;
using Microsoft.EntityFrameworkCore;
using LabRab5App.Persistence.Data;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace LabRab5App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            string settingsStream = "LabRab5App.appsettings.json";

            var builder = MauiApp.CreateBuilder();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("icofont.ttf", "IcoFont");
                    fonts.AddFont("FontAwesome.ttf", "fontawesome");
                });

            var connectrionString = builder.Configuration.GetConnectionString("SqliteConnection");
            var dataDirectory = FileSystem.Current.AppDataDirectory;
            dataDirectory += "\\";
            connectrionString = String.Format(connectrionString, dataDirectory);
            Trace.WriteLine(connectrionString);
            var options = new DbContextOptionsBuilder<AppDbContext>().EnableSensitiveDataLogging().UseSqlite(connectrionString).Options;
            
            builder.Services.AddApplication();
            builder.Services.AddPersistence(options);
            builder.Services.RegisterPages();
            builder.Services.RegisterViewModels();

            DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
