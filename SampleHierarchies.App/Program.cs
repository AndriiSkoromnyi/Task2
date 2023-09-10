// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;
using SampleHierarchies.Data;
using SampleHierarchies.Gui;
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
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
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
