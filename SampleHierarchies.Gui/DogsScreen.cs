using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;


namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Mammals main screen.
    /// </summary>
    public sealed class DogsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>

        private IDataService _dataService;
        private ISettings _settings;
        private ISettingsService _settingsService;

        private string jsonFile = "DogsScreen.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        /// <param name="settings">Settings reference</param>
        public DogsScreen(IDataService dataService, ISettings settings, ISettingsService settingsService)
        {
            _dataService = dataService;
            _settings = settings;
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
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 2); // "1. List all dogs"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 3); // "2. Create a new dog"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 4); // "3. Delete existing dog"
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 5); // "4. Modify existing dog"
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

                    DogsScreenChoices choice = (DogsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case DogsScreenChoices.List:
                            ListDogs();
                            break;

                        case DogsScreenChoices.Create:
                            AddDog();
                            break;

                        case DogsScreenChoices.Delete:
                            DeleteDog();
                            break;

                        case DogsScreenChoices.Modify:
                            EditDogMain();
                            break;

                        case DogsScreenChoices.Exit:
                            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 7); // "Going back to parent menu."
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 8); // "Invalid choice. Try again."
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all dogs.
        /// </summary>
        private void ListDogs()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Dogs is not null &&
                _dataService.Animals.Mammals.Dogs.Count > 0)
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 9);//Here's a list of dogs:
                int i = 1;
                foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
                {
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 10); Console.Write($"{i}");
                    
                    dog.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 11);
            }
        }

        /// <summary>
        /// Add a dog.
        /// </summary>
        private void AddDog()
        {
            try
            {
                Dog dog = AddEditDog();
                _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 12);
            }
            catch
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 13);
            }
        }

        /// <summary>
        /// Deletes a dog.
        /// </summary>
        private void DeleteDog()
        {
            try
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (dog is not null)
                {
                    _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 15);
                }
                else
                {
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 16);
                }
            }
            catch
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 17);
            }
        }

        /// <summary>
        /// Edits an existing dog after choice made.
        /// </summary>
        private void EditDogMain()
        {
            try
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (dog is not null)
                {
                    Dog dogEdited = AddEditDog();
                    dog.Copy(dogEdited);
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 19);
                    dog.Display();
                }
                else
                {
                    ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 20);
                }
            }
            catch
            {
                ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 21);
            }
        }

        /// <summary>
        /// Adds/edit specific dog.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Dog AddEditDog()
        {
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.DisplayScreenLinesWithColors(jsonFile, 24);
            string? breed = Console.ReadLine();

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
            int age = Int32.Parse(ageAsString);
            Dog dog = new Dog(name, age, breed);

            return dog;
        }

        #endregion // Private Methods
    }
}
