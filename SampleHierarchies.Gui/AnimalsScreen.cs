using System;
using System.Drawing;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Animals main screen.
    /// </summary>
    public sealed class AnimalsScreen : Screen
    {
        #region Properties And Ctor

        private IDataService _dataService;
        private MammalsScreen _mammalsScreen;
        private ISettingsService _settingsService;
        private ISettings _settings;

        public AnimalsScreen(
            IDataService dataService,
            MammalsScreen mammalsScreen,
            ISettingsService settingsService,
            ISettings settings)
        {
            _dataService = dataService;
            _mammalsScreen = mammalsScreen;
            _settingsService = settingsService;
            _settings = settings;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Mammals");
                Console.WriteLine("2. Save to file");
                Console.WriteLine("3. Read from file");
                Console.WriteLine("4. Change text color");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AnimalsScreenChoices.Mammals:
                            _mammalsScreen.Show();
                            break;

                        case AnimalsScreenChoices.Read:
                            ReadFromFile();
                            break;

                        case AnimalsScreenChoices.Save:
                            SaveToFile();
                            break;

                        case AnimalsScreenChoices.ChangeTextColor: // Обработка нового варианта выбора
                            ChangeTextColor();
                            break;

                        case AnimalsScreenChoices.Exit:
                            Console.WriteLine("Going back to parent menu.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void ChangeTextColor()
        {
            try
            {
                Console.Write("Enter the text color (e.g., Red, Green, Blue) or its numeric code (0 - 15): ");
                string? colorInput = Console.ReadLine();

                if (colorInput is not null && !string.IsNullOrWhiteSpace(colorInput))
                {
                    if (Enum.TryParse(colorInput, out ConsoleColor consoleColor))
                    {
                        // Convert ConsoleColor to Color for storing in settings
                        Color color = Color.FromName(consoleColor.ToString());
                        _settings.AnimalsScreenTextColor = color;

                        Console.ForegroundColor = consoleColor;
                        Console.WriteLine("Text color has been changed. This is the new text color.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Invalid color input. Text color remains unchanged.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Text color remains unchanged.");
                }
            }
            catch
            {
                Console.WriteLine("Error occurred while changing text color. Text color remains unchanged.");
            }
        }

        #endregion // Private Methods

        #region Private Methods

        private void SaveToFile()
        {
            try
            {
                Console.Write("Save data to file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                // Save text colors to settings before saving to file
                _settingsService.Write(_settings, fileName);
                Console.WriteLine("Data saving to: '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Data saving was not successful.");
            }
        }

        private void ReadFromFile()
        {
            try
            {
                Console.Write("Read data from file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                _settings = _settingsService.Read(fileName);

                if (_settings is not null)
                {
                    // Use the loaded settings to set colors of different screens
                    SetTextColorsFromSettings();
                    Console.WriteLine("This is the Animals Screen.");
                }
                else
                {
                    Console.WriteLine("Data reading from: '{0}' was not successful.", fileName);
                }
            }
            catch
            {
                Console.WriteLine("Data reading was not successful.");
            }
        }

        private void SetTextColorsFromSettings()
        {
            Console.ForegroundColor = (ConsoleColor)_settings.HomeScreenTextColor.ToArgb();
            Console.Clear();
            Console.WriteLine("This is the Home Screen.");
            Console.ForegroundColor = (ConsoleColor)_settings.AnimalsScreenTextColor.ToArgb();
            Console.Clear();
            Console.WriteLine("This is the Animals Screen.");
            Console.ForegroundColor = (ConsoleColor)_settings.MammalsScreenTextColor.ToArgb();
            Console.Clear();
            Console.WriteLine("This is the Mammals Screen.");
            Console.ForegroundColor = (ConsoleColor)_settings.DogsScreenTextColor.ToArgb();
            Console.Clear();
            Console.WriteLine("This is the Dogs Screen.");
        }

        #endregion // Private Methods
    }
}
