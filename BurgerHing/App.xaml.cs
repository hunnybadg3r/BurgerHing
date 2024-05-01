using BurgerHing.Main.Controls.Views;
using BurgerHing.Main.Local.ViewModels;
using BurgerHing.Support.Local.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace BurgerHing;

public partial class App : Application
{
    public static IHost AppHost { get; private set; }
    public static IConfiguration Config { get; private set; }

    public App()
    {
        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // View, ViewModels
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                
                services.AddTransient<PayStepLayoutViewModel>();
                services.AddTransient<PayStepOrderTypeViewModel>();
                services.AddTransient<PayStepPaymentViewModel>();
                services.AddTransient<PayStepOrderResultViewModel>();

                // Services
                services.AddSingleton<IMenuService, MenuService>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startup = AppHost.Services.GetRequiredService<MainWindow>();
        startup.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
