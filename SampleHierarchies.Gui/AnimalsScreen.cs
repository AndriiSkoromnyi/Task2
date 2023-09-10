using SampleHierarchies.Enums;
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

        private string jsonFile = "AnimalsScreen.json";

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
                // Display line 0 from JSON (Header)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 0);

                // Display line 1 from JSON (Menu option: "0. Exit")
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 1);

                // Display line 2 from JSON (Menu option: "1. Mammals")
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2);

                // Display line 3 from JSON (Menu option: "2. Save to file")
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3);

                // Display line 4 from JSON (Menu option: "3. Read from file")
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4);

                // Display line 5 from JSON (Prompt)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5);

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

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

                        case AnimalsScreenChoices.Exit:
                            // Display line 6 from JSON (Going back to parent menu.)
                            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 6);
                            return;
                    }
                }
                catch
                {
                    // Display line 7 from JSON (Invalid choice. Try again.)
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 7);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void SaveToFile()
        {
            try
            {
                // Display line 8 from JSON (Save data to file)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 8);
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                // Save text colors to settings before saving to file
                _settingsService.Write(_settings, fileName);
                // Display line 9 from JSON (File name)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 9);
            }
            catch
            {
                // Display line 10 from JSON (Data saving was not successful)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 10);
            }
        }

        private void ReadFromFile()
        {
            try
            {
                // Display line 11 from JSON (Read data from file)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 11);
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                _settings = _settingsService.Read(fileName);

                if (_settings is not null)
                {
                    
                    // Display line 12 from JSON (This is the Animals Screen.)
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 12);
                }
                else
                {
                    // Display line 13 from JSON (File name)
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 13); Console.WriteLine(fileName);
                }
            }
            catch
            {
                // Display line 14 from JSON (Data reading was not successful)
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 14);
            }
        }

        #endregion // Private Methods
    }
}
