using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;


public sealed class RabbitScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public RabbitScreen(IDataService dataService)
    {
        _dataService = dataService;
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
            Console.WriteLine("1. List all rabbits");
            Console.WriteLine("2. Create a new rabbit");
            Console.WriteLine("3. Delete existing rabbit");
            Console.WriteLine("4. Modify existing rabbit");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

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

    /// <summary>
    /// List all rabbits.
    /// </summary>
    private void ListRabbit()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Rabbits is not null &&
            _dataService.Animals.Mammals.Rabbits.Count > 0)
        {
            Console.WriteLine("Here's a list of Rabbits:");
            int i = 1;
            foreach (Rabbit rabbit in _dataService.Animals.Mammals.Rabbits)
            {
                Console.Write($"Rabbit number {i}, ");
                rabbit.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of rabbits is empty.");
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
            Console.WriteLine("Rabbit with name: {0} has been added to the list of rabbits", rabbit.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a rabbit.
    /// </summary>
    private void DeleteRabbit()
    {
        try
        {
            Console.Write("What is the name of the rabbit you want to delete? ");
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
                Console.WriteLine("Rabbit with name: {0} has been deleted from the list of rabbits", rabbit.Name);
            }
            else
            {
                Console.WriteLine("Rabbit not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing rabbit after choice made.
    /// </summary>
    private void EditRabbitMain()
    {
        try
        {
            Console.Write("What is the name of the rabbit you want to edit? ");
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
                Console.Write("Rabbit after edit:");
                rabbit.Display();
            }
            else
            {
                Console.WriteLine("Rabbit not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific rabbit.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Rabbit AddEditRabbit()
    {
        Console.Write("What name of the rabbit? ");
        string? name = Console.ReadLine();
        Console.Write("What is the rabbit's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("How much does rabbit weigh (kg)? ");
        string? weightAsString = Console.ReadLine();
        Console.Write("Write a type of your rabbit: Dutch, Mini Lop, Lionhead, Angora, or something else ");
        string? typeOfRabbit = Console.ReadLine();

        Console.Write("Does the rabbit have an owner? (Y/N): ");
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
                Console.WriteLine("ERROR - Invalid input. Assuming no owner.");
                hasOwner = false;
            }
        }
        else
        {
            Console.WriteLine("ERROR - Invalid input. Assuming no owner.");
            hasOwner = false;
        }
        Console.Write("Which food prefer?");
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