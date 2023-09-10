using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;


public sealed class CatScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettingsService _settingsService;

    private string jsonFile = "CatScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public CatScreen(IDataService dataService, ISettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;
    }
    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 0); // "Your available choices are:"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 1); // "0. Exit"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2); // "1. List all cats"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3); // "2. Create a new cat"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4); // "3. Delete existing cat"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5); // "4. Modify existing cat"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 6); // "Please enter your choice:"

            string? choiceAsString = Console.ReadLine();
            Console.ResetColor();
            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                CatsScreenChoices choice = (CatsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case CatsScreenChoices.List:
                        ListCat();
                        break;

                    case CatsScreenChoices.Create:
                        AddCat();
                        break;

                    case CatsScreenChoices.Delete:
                        DeleteCat();
                        break;

                    case CatsScreenChoices.Modify:
                        EditCatMain();
                        break;

                    case CatsScreenChoices.Exit:
                        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 7);//"Going back to parent menu."
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 8);//"Invalid choice. Try again."
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all cats.
    /// </summary>
    private void ListCat()
    {
        if (_dataService?.Animals?.Mammals?.Cats is not null &&
            _dataService.Animals.Mammals.Cats.Count > 0)
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 9);//"Here's a list of Cats:"
            int i = 1;
            foreach (Cat cat in _dataService.Animals.Mammals.Cats)
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 10); Console.Write($"{i}");  //"Cat number {i}, "
                cat.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 11);//"The list of cats is empty."
        }
    }

    /// <summary>
    /// Add a cat.
    /// </summary>
    private void AddCat()
    {
        try
        {
            Cat cat = AddEditCat();
            _dataService?.Animals?.Mammals?.Cats?.Add(cat);
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 12);//"Cat with name: {0} has been added to the list of cats", cat.Name
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 13);//"Invalid input."
        }
    }

    /// <summary>
    /// Deletes a cat.
    /// </summary>
    private void DeleteCat()
    {
        try
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 14);//"What is the name of the cat you want to delete? "
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Cat? cat = (Cat?)(_dataService?.Animals?.Mammals?.Cats
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (cat is not null)
            {
                _dataService?.Animals?.Mammals?.Cats?.Remove(cat);
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 15);//"Cat with this name: has been deleted from the list of cats", cat.Name
            }
            else
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 16);//"Cat not found."
            }
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 17);//"Invalid input."
        }
    }

    /// <summary>
    /// Edits an existing cat after choice made.
    /// </summary>
    private void EditCatMain()
    {
        try
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 18);//"What is the name of the cat you want to edit? "
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Cat? cat = (Cat?)(_dataService?.Animals?.Mammals?.Cats
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (cat is not null)
            {
                Cat catEdited = AddEditCat();
                cat.Copy(catEdited);
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 19);//"Cat after edit:"
                cat.Display();
            }
            else
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 20);//"Cat not found."
            }
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 21);//"Invalid input. Try again."
        }
    }

    /// <summary>
    /// Adds/edit specific cat.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Cat AddEditCat()
    {
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 22);//"What name of the cat? "
            string? name = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 23);//"What is the cat's age? "
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 24);//"How much does cat weigh (kg)? "
            string? weightAsString = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 25);//"Write a type of your cat: Persian, Siamese, Bengal, Russian Blue, or something else "
            string? typeOfCat = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 26);//"Does the cat have an owner? (Y/N): "
            string? hasOwnerInput = Console.ReadLine();

            bool hasOwner = false;
            if (hasOwnerInput is not null)
            {
                if (hasOwnerInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    hasOwner = true;
                }
                else if (hasOwnerInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    hasOwner = false;
                }
                else
                {
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 27);//"ERROR - Invalid input. Assuming no owner."
                    hasOwner = false;
                }
            }
           

            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 28);//"Which food prefer?"
            string? foodPreference = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (typeOfCat is null)
            {
                throw new ArgumentNullException(nameof(typeOfCat));
            }
            if (foodPreference is null)
            {
                throw new ArgumentNullException(nameof(foodPreference));
            }

            int age = Int32.Parse(ageAsString);
            int weight = Int32.Parse(weightAsString);

            Cat cat = new Cat(name, age, weight, typeOfCat, hasOwner, foodPreference);

            return cat;
        }
    }
}
    #endregion


