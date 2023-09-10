using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Mammals main screen.
    /// </summary>
    public sealed class MammalsScreen : Screen
    {
        #region Properties And Ctor

        private DogsScreen _dogsScreen;
        private HorseScreen _horsesScreen;
        private RabbitScreen _rabbitScreen;
        private CatScreen _catScreen;
        private ISettingsService _settingsService;

        private string jsonFile = "MammalsScreen.json";

        public MammalsScreen(DogsScreen dogsScreen, HorseScreen horseScreen, RabbitScreen rabbitScreen, CatScreen catScreen, ISettingsService settingsService)
        {
            _horsesScreen = horseScreen;
            _dogsScreen = dogsScreen;
            _rabbitScreen = rabbitScreen;
            _catScreen = catScreen;
            _settingsService = settingsService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                // Set the foreground color based on settings
                Console.ForegroundColor = _settingsService.Settings._mammalScreenForegroundColor;
                Console.WriteLine();

                // Display the menu options using ScreenDefinitionService
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 0); // Header
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 1); // Menu option: "0. Exit"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2); // Menu option: "1. Dogs"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3); // Menu option: "2. Horses"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4); // Menu option: "3. Rabbit"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5); // Menu option: "4. Cat"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 6); // Prompt

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MammalsScreenChoices.Dogs:
                            _dogsScreen.Show();
                            break;

                        case MammalsScreenChoices.Horses:
                            _horsesScreen.Show();
                            break;

                        case MammalsScreenChoices.Rabbit:
                            _rabbitScreen.Show();
                            break;

                        case MammalsScreenChoices.Cat:
                            _catScreen.Show();
                            break;

                        case MammalsScreenChoices.Exit:
                            Console.WriteLine("Going back to the parent menu.");
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
    }
}
