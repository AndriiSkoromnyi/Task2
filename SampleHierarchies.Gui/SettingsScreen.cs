using System;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.UserInterface
{
    public class SettingsScreen
    {
        private ISettingsService _settingsService;

        public SettingsScreen(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        private ConsoleColor GetConsoleColorFromUserInput()
        {
            Console.WriteLine("Available ConsoleColors:");
            foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.WriteLine($"{(int)color}. {color}");
            }

            Console.Write("Enter the number for the desired ConsoleColor: ");
            if (int.TryParse(Console.ReadLine(), out int colorNumber) && Enum.IsDefined(typeof(ConsoleColor), colorNumber))
            {
                return (ConsoleColor)colorNumber;
            }
            else
            {
                Console.WriteLine("Invalid input. Using default ConsoleColor.");
                return ConsoleColor.Gray; // Default color
            }
        }


        public void Show()
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
                            ConsoleColor mainScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._mainScreenForegroundColor = mainScreenColor;
                            break;
                            
                        case SettingsMenuChoices.SetAnimalScreenColor:
                            Console.WriteLine("Setting AnimalScreen color.");
                            ConsoleColor animalScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._animalScreenForegroundColor = animalScreenColor;
                            break;

                        case SettingsMenuChoices.SetMammalsScreenColor:
                            Console.WriteLine("Setting MammalsScreen color.");
                            ConsoleColor mammalsScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._mammalScreenForegroundColor = mammalsScreenColor;
                            break;

                        case SettingsMenuChoices.SetDogScreenColor:
                            Console.WriteLine("Setting DogScreen color.");
                            ConsoleColor dogScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._dogScreenForegroundColor = dogScreenColor;
                            break;

                        case SettingsMenuChoices.SetHorseScreenColor:
                            Console.WriteLine("Setting HorseScreen color.");
                            ConsoleColor horseScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._horseScreenForegroundColor = horseScreenColor;
                            break;

                        case SettingsMenuChoices.SetRabbitScreenColor:
                            Console.WriteLine("Setting RabbitScreen color.");
                            ConsoleColor rabbitScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._rabbitScreenForegroundColor = rabbitScreenColor;
                            break;

                        case SettingsMenuChoices.SetCatScreenColor:
                            Console.WriteLine("Setting CatScreen color.");
                            ConsoleColor catScreenColor = GetConsoleColorFromUserInput();
                            _settingsService.Settings._catScreenForegroundColor = catScreenColor;
                            break;

                        case SettingsMenuChoices.ReadSettingsFromFile:
                            Console.WriteLine("Reading settings from file.");
                            Interfaces.Data.ISettings loadedSettings = _settingsService.Read("path_to_settings_file.json");
                            _settingsService.Settings = loadedSettings;
                            break;

                        case SettingsMenuChoices.WriteSettingsToFile:
                            Console.WriteLine("Writing settings to file.");
                            _settingsService.Write(_settingsService.Settings, "path_to_settings_file.json");
                            break;

                        case SettingsMenuChoices.Exit:
                            Console.WriteLine("Exiting settings.");
                            return;

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