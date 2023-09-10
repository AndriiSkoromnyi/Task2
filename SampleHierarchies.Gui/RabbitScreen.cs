using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;


public sealed class RabbitScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettingsService _settingsService;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>

    private string jsonFile = "RabbitScreen.json";

    public RabbitScreen(IDataService dataService, ISettingsService settingsService)
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
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2); // "1. List all Rabbits"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3); // "2. Create a new Rabbit"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4); // "3. Delete existing Rabbit"
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5); // "4. Modify existing Rabbit"
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

                RabbitsScreenChoices choice = (RabbitsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case RabbitsScreenChoices.List:
                        ListRabbit();
                        break;

                    case RabbitsScreenChoices.Create:
                        AddRabbit();
                        break;

                    case RabbitsScreenChoices.Delete:
                        DeleteRabbit();
                        break;

                    case RabbitsScreenChoices.Modify:
                        EditRabbitMain();
                        break;



                    case RabbitsScreenChoices.Exit:
                        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 7);//"Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 8);//"Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all rabbits.
    /// </summary>
    private void ListRabbit()
    {
        if (_dataService?.Animals?.Mammals?.Rabbits is not null &&
            _dataService.Animals.Mammals.Rabbits.Count > 0)
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 9);//"Here's a list of Rabbits:");
            int i = 1;
            foreach (Rabbit rabbit in _dataService.Animals.Mammals.Rabbits)
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 10); Console.Write($"{i}");//($"Rabbit number {i}, ");
                rabbit.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 11);//"The list of rabbits is empty.");
        }
    }

    /// <summary>
    /// Add a rabbit.
    /// </summary>
    private void AddRabbit()
    {
        try
        {
            Rabbit rabbit = AddEditRabbit();
            _dataService?.Animals?.Mammals?.Rabbits?.Add(rabbit);
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 12);//"Rabbit with name: {0} has been added to the list of rabbits", rabbit.Name);
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 13);//"Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a rabbit.
    /// </summary>
    private void DeleteRabbit()
    {
        try
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 14);//("What is the name of the rabbit you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Rabbit? rabbit = (Rabbit?)(_dataService?.Animals?.Mammals?.Rabbits
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (rabbit is not null)
            {
                _dataService?.Animals?.Mammals?.Rabbits?.Remove(rabbit);
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 15);//"Rabbit with name: {0} has been deleted from the list of rabbits", rabbit.Name);
            }
            else
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 16);//"Rabbit not found.");
            }
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 17);//"Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing rabbit after choice made.
    /// </summary>
    private void EditRabbitMain()
    {
        try
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 18);//("What is the name of the rabbit you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Rabbit? rabbit = (Rabbit?)(_dataService?.Animals?.Mammals?.Rabbits
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (rabbit is not null)
            {
                Rabbit rabbitEdited = AddEditRabbit();
                rabbit.Copy(rabbitEdited);
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 19);//("Rabbit after edit:");
                rabbit.Display();
            }
            else
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 20);//"Rabbit not found.");
            }
        }
        catch
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 21);//"Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific rabbit.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Rabbit AddEditRabbit()
    {
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 22);//"What name of the rabbit? ")
        string? name = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 23);//"What is the rabbit's age? "
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 24);//"How much does rabbit weigh (kg)? "
        string? weightAsString = Console.ReadLine();
        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 25);//"Write a type of your rabbit: Dutch, Mini Lop, Lionhead, Angora, or something else "
        string? typeOfRabbit = Console.ReadLine();

        ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 26);//"Does the rabbit have an owner? (Y/N): "
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
        string? food = Console.ReadLine();

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
        if (typeOfRabbit is null)
        {
            throw new ArgumentNullException(nameof(typeOfRabbit));
        }
        if (food is null)
        {
            throw new ArgumentNullException(nameof(food));
        }

        int age = Int32.Parse(ageAsString);
        int weight = Int32.Parse(weightAsString);
        
        Rabbit rabbit = new Rabbit (name, age, weight, typeOfRabbit, hasOwner, food);
        
        return rabbit;
    }
    #endregion
}