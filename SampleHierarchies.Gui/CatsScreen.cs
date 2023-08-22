using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;


public sealed class CatScreen : Screen
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
    public CatScreen(IDataService dataService)
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
            Console.WriteLine("1. List all cats");
            Console.WriteLine("2. Create a new cat");
            Console.WriteLine("3. Delete existing cat");
            Console.WriteLine("4. Modify existing cat");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

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
    /// List all cats.
    /// </summary>
    private void ListCat()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Cats is not null &&
            _dataService.Animals.Mammals.Cats.Count > 0)
        {
            Console.WriteLine("Here's a list of Cats:");
            int i = 1;
            foreach (Cat cat in _dataService.Animals.Mammals.Cats)
            {
                Console.Write($"Cat number {i}, ");
                cat.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of cats is empty.");
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
            Console.WriteLine("Cat with name: {0} has been added to the list of cats", cat.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a cat.
    /// </summary>
    private void DeleteCat()
    {
        try
        {
            Console.Write("What is the name of the cat you want to delete? ");
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
                Console.WriteLine("Cat with name: {0} has been deleted from the list of cats", cat.Name);
            }
            else
            {
                Console.WriteLine("Cat not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing cat after choice made.
    /// </summary>
    private void EditCatMain()
    {
        try
        {
            Console.Write("What is the name of the cat you want to edit? ");
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
                Console.Write("Cat after edit:");
                cat.Display();
            }
            else
            {
                Console.WriteLine("Cat not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific cat.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Cat AddEditCat()
    {
        {
            Console.Write("What name of the cat? ");
            string? name = Console.ReadLine();
            Console.Write("What is the cat's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("How much does cat weigh (kg)? ");
            string? weightAsString = Console.ReadLine();
            Console.Write("Write a type of your cat: Persian, Siamese, Bengal, Russian Blue, or something else ");
            string? typeOfCat = Console.ReadLine();
            Console.Write("Does the cat have an owner? (Y/N): ");
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


