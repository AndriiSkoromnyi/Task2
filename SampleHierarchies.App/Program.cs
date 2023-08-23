// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;
using SampleHierarchies.Data;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using SampleHierarchies.UserInterface;
using System;

namespace ImageTagger.FrontEnd.WinForms
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; } = null;

        [STAThread]
        static void Main(string[] args)
        {
            // Build and configure the service provider
            ServiceProvider = CreateHostBuilder().Build().Services;

            ISettingsService settingsService = ServiceProvider.GetRequiredService<ISettingsService>();
            AnimalsScreen animalsScreen = new AnimalsScreen(
                ServiceProvider.GetRequiredService<IDataService>(),
                ServiceProvider.GetRequiredService<MammalsScreen>(),
                settingsService,
                settingsService.Settings); // Using the actual settings object
            SettingsScreen settingsScreen = ServiceProvider.GetRequiredService<SettingsScreen>();
            MainScreen mainScreen = new MainScreen(settingsService, animalsScreen, settingsScreen);

            mainScreen.ShowMainMenu();

        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ISettings, Settings>();
                    services.AddSingleton<ISettingsService, SettingsService>();
                    services.AddSingleton<IEventAggregator, EventAggregator>();
                    services.AddSingleton<IDataService, DataService>();
                    services.AddSingleton<MainScreen, MainScreen>();
                    services.AddSingleton<DogsScreen, DogsScreen>();
                    services.AddSingleton<AnimalsScreen, AnimalsScreen>();
                    services.AddSingleton<MammalsScreen, MammalsScreen>();
                    services.AddSingleton<HorseScreen, HorseScreen>();
                    services.AddSingleton<RabbitScreen, RabbitScreen>();
                    services.AddSingleton<CatScreen, CatScreen>();
                    services.AddSingleton<SettingsScreen, SettingsScreen>();
                });
        }

    }
}
