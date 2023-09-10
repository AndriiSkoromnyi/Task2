using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.UserInterface
{
    public class MainScreen
    {
        private ISettingsService _settingsService;
        private AnimalsScreen _animalsScreen;
        private SettingsScreen _settingsScreen;

        

        private string jsonFile = "MainScreen.json";

        public MainScreen(ISettingsService settingsService, AnimalsScreen animalsScreen, SettingsScreen settingsScreen)
        {
            _settingsService = settingsService;
            _animalsScreen = animalsScreen;
            _settingsScreen = settingsScreen;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 0);//"Enter your choise: "
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 1);//"0. Exit"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2);//"1. Animals"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3);//"2. Manage Settings"

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

                if (!string.IsNullOrEmpty(choiceAsString) && int.TryParse(choiceAsString, out int choice))
                {
                    switch ((MainScreenChoices)choice)
                    {
                        case MainScreenChoices.Animals:
                            _animalsScreen.Show();
                            break;

                        case MainScreenChoices.Settings:
                            _settingsScreen.Show();
                            break;

                        case MainScreenChoices.Exit:
                            return;
                    }
                }
            }
        }
    }
}