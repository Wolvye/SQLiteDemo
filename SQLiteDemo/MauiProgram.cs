using Microsoft.Extensions.Logging;
using SQLiteDemo.MVVM.Models;
using SQLiteDemo.MVVM.Views;
using SQLiteDemo.Repositories;

namespace SQLiteDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var repo = new CustomerRepository();
            App.CustomerRepo = repo;
            App.OrdersRepo = new BaseRepository<Order>();


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(repo);
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<BaseRepository<Customer>>();
            builder.Services.AddSingleton<BaseRepository<Order>>();



            SQLitePCL.Batteries_V2.Init();

            return builder.Build();
        }
    }
}
