using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;


public sealed class HorseScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettingsService _settingsService;

    private string jsonFile = "HorseScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public HorseScreen(IDataService dataService, ISettingsService settingsService)
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
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2); // "1. List all horse"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3); // "2. Create a new horse"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4); // "3. Delete existing horse"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5); // "4. Modify existing horse"
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

                HorsesScreenChoices choice = (HorsesScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case HorsesScreenChoices.List:
                        ListHorse();
                        break;

                    case HorsesScreenChoices.Create:
                        AddHorse(); break;

                    case HorsesScreenChoices.Delete:
                        DeleteHorse();
                        break;

                    case HorsesScreenChoices.Modify:
                        EditHorseMain();
                        break;

                    case HorsesScreenChoices.Exit:
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
    /// List all dogs.
    /// </summary>
    private void ListHorse()
    {
        
        if (_dataService?.Animals?.Mammals?.Horses is not null &&
            _dataService.Animals.Mammals.Horses.Count > 0)
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 9);//"Here's a list of Horses:"
            int i = 1;
            foreach (Horse horse in _dataService.Animals.Mammals.Horses)
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 10); Console.Write($"{i}");//"Horse number 

                horse.Display();
                i++;
            }
        }
        else
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 11);//"The list of horsess is empty."
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddHorse()
    {
        try
        {
            Horse horse = AddEditHorse();
            _dataService?.Animals?.Mammals?.Horses?.Add(horse);
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 12);//"Horse with this name: has been added to a list of horses"
        }
        catch
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 13);//"Invalid input."
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteHorse()
    {
        try
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 14);//"What is the name of the horse you want to delete? "
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Horse? horse = (Horse?)(_dataService?.Animals?.Mammals?.Horses
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (horse is not null)
            {
                _dataService?.Animals?.Mammals?.Horses?.Remove(horse);
                 ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 15);//"Horse with this name: has been deleted from a list of horses"
            }
            else
            {
                 ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 16);//"Horse not found."
            }
        }
        catch
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 17);//"Invalid input."
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditHorseMain()
    {
        try
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 18);//"What is the name of the horse you want to edit? "
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Horse? horse = (Horse?)(_dataService?.Animals?.Mammals?.Horses
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (horse is not null)
            {
                Horse horseEdited = AddEditHorse();
                horse.Copy(horseEdited);
                 ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 19);//"Horse after edit:"
                horse.Display();
            }
            else
            {
                 ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 20);//"Horse not found."
            }
        }
        catch
        {
             ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 21);//"Invalid input. Try again."
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Horse AddEditHorse()
    {
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 22);//"What name of the horse? "
        string? name = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 23);//"What is the horse's age? "
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 24);//"What is the horse's breed? "
        string? breed = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 25);//("What is the horse's color? "
        string? color = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 26);//"How much does horse weight (kg)? "
        string? weightAsString = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 27);//"Write a type of your horse: Pony, Working horse, Sport horse, Draft horse, Riding horse or smt. another "
        string? typeOfHorse = Console.ReadLine();
       



        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        if (color is null)
        {
            throw new ArgumentNullException(nameof(color));
        }
        if (weightAsString is null)
        {
            throw new ArgumentNullException(nameof(weightAsString));
        }
        if (typeOfHorse is null)
        {
            throw new ArgumentNullException(nameof(typeOfHorse));
        }
        int age = Int32.Parse(ageAsString);
        int weight = Int32.Parse(weightAsString);
        Horse horse = new Horse(name, age, breed, color, weight, typeOfHorse);

        return horse;




        
    }
    #endregion
}