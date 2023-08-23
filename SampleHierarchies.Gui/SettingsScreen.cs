using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;
using System;

namespace SampleHierarchies.UserInterface
{
    public class SettingsScreen
    {
        private ISettingsService _settingsService;
        private MainScreen _mainScreen;
        private AnimalsScreen _animalsScreen;

        public SettingsScreen(ISettingsService settingsService, MainScreen mainScreen, AnimalsScreen animalsScreen)
        {
            _settingsService = settingsService;
            _mainScreen = mainScreen;
            _animalsScreen = animalsScreen;
        }

        public void ShowSettingsMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Settings Menu:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Set MainScreen color");
                Console.WriteLine("2. Set AnimalScreen color");
                Console.WriteLine("3. Set MammalsScreen color");
                Console.WriteLine("4. Set DogScreen color");
                Console.WriteLine("5. Set HorseScreen color");
                Console.WriteLine("6. Set RabbitScreen color");
                Console.WriteLine("7. Set CatScreen color");
                Console.WriteLine("8. Read settings from file");
                Console.WriteLine("9. Write settings to file");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    SettingsMenuChoices choice = (SettingsMenuChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {

                        case SettingsMenuChoices.SetMainScreenColor:
                            Console.WriteLine("Setting MainScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._mainScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetAnimalScreenColor:
                            Console.WriteLine("Setting AnimalScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._animalScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetMammalsScreenColor:
                            Console.WriteLine("Setting MammalsScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._mammalScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetDogScreenColor:
                            Console.WriteLine("Setting DogScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._dogScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetHorseScreenColor:
                            Console.WriteLine("Setting HorseScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._horseScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetRabbitScreenColor:
                            Console.WriteLine("Setting RabbitScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._rabbitScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;

                        case SettingsMenuChoices.SetCatScreenColor:
                            Console.WriteLine("Setting CatScreen color.");
                            ConsoleColor newColor = // Get user input for the new color
                            _settingsService.Settings._catScreenForegroundColor = newColor;
                            _settingsService.Write(_settingsService.Settings, "settings.json");
                            break;




                        // TODO: Implement other cases for different screen colors and settings

                        case SettingsMenuChoices.ReadSettingsFromFile:
                            Console.WriteLine("Reading settings from file.");
                            // TODO: Implement reading settings from a file
                            break;

                        case SettingsMenuChoices.WriteSettingsToFile:
                            Console.WriteLine("Writing settings to file.");
                            // TODO: Implement writing settings to a file
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
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