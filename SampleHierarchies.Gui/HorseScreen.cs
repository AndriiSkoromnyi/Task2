
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class HorseScreen : Screen
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
            Console.ForegroundColor = _settingsService.Settings._horseScreenForegroundColor;
            Console.WriteLine();          
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all horse");
            Console.WriteLine("2. Create a new horse");
            Console.WriteLine("3. Delete existing horse");
            Console.WriteLine("4. Modify existing horse");
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
    /// List all dogs.
    /// </summary>
    private void ListHorse()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Horses is not null &&
            _dataService.Animals.Mammals.Horses.Count > 0)
        {
            Console.WriteLine("Here's a list of Horses:");
            int i = 1;
            foreach (Horse horse in _dataService.Animals.Mammals.Horses)
            {
                Console.Write($"Horse number {i}, ");
                horse.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of horsess is empty.");
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
            Console.WriteLine("Horse with name: {0} has been added to a list of horses", horse.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteHorse()
    {
        try
        {
            Console.Write("What is the name of the horse you want to delete? ");
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
                Console.WriteLine("Horse with name: {0} has been deleted from a list of horses", horse.Name);
            }
            else
            {
                Console.WriteLine("Horse not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditHorseMain()
    {
        try
        {
            Console.Write("What is the name of the horse you want to edit? ");
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
                Console.Write("Horse after edit:");
                horse.Display();
            }
            else
            {
                Console.WriteLine("Horse not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Horse AddEditHorse()
    {
        Console.Write("What name of the horse? ");
        string? name = Console.ReadLine();
        Console.Write("What is the horse's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the horse's breed? ");
        string? breed = Console.ReadLine();
        Console.Write("What is the horse's color? ");
        string? color = Console.ReadLine();
        Console.Write("How much does horse weight (kg)? ");
        string? weightAsString = Console.ReadLine();
        Console.Write("Write a type of your horse: Pony, Working horse, Sport horse, Draft horse, Riding horse or smt. another ");
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