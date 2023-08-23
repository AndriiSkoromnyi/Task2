using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;
    private HorseScreen _horsesScreen;
    private RabbitScreen _rabbitScreen;
    private CatScreen _catScreen;
    private ISettingsService _settingsService;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// <param name="horseScreen">Horse screen</param>
    /// <param name="rabbitScreen">Horse screen</param>
    /// <param name="catScreen">Horse screen</param>

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
            Console.ForegroundColor = _settingsService.Settings._mammalScreenForegroundColor;
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Horses");
            Console.WriteLine("3. Rabbit");
            Console.WriteLine("4. Cat");
            Console.Write("Please enter your choice: ");

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
}
