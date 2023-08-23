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
                Console.ForegroundColor = _settingsService.Settings._mainScreenForegroundColor;
                Console.WriteLine();

                Console.WriteLine("Main Menu");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Open Animals Screen");
                Console.WriteLine("2. Manage Settings");
                Console.Write("Enter your choice: ");

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MainScreenChoices.Animals:
                            _animalsScreen.Show();
                            break;

                        case MainScreenChoices.Settings:                            
                            bool settingsChanged = _settingsScreen.Show();
                            if (settingsChanged)
                            {
                                continue; 
                            }
                            break; ;

                        case MainScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
