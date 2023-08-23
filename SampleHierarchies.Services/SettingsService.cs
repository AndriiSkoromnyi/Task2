using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Services
{
    public class SettingsService : ISettingsService
    {
        private ISettings _settings;

        public SettingsService()
        {
            
            _settings = new Settings();
            _screenColors = new Dictionary<string, ConsoleColor>
            {
                { "MainScreen", _settings.MainScreenForegroundColor },
                { "AnimalScreen", _settings.AnimalScreenForegroundColor },
                { "MammalScreen", _settings.MammalScreenForegroundColor },
                { "DogScreen", _settings.DogScreenForegroundColor },
                { "CatScreen", _settings.CatScreenForegroundColor },
                { "RabbitScreen", _settings.RabbitScreenForegroundColor },
                { "HorseScreen", _settings.HorseScreenForegroundColor },

            };
        }

        public ISettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }



        public ISettings Read(string jsonPath)
        {
            ISettings result = null;

            try
            {
                string jsonData = File.ReadAllText(jsonPath);
                result = JsonConvert.DeserializeObject<Settings>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading JSON file: " + ex.Message);
            }

            return result;
        }

        public void Write(ISettings settings, string jsonPath)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonPath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing to JSON file: " + ex.Message);
            }
        }

        public ConsoleColor GetScreenForegroundColor(string screenName)
        {
            if (_screenColors.ContainsKey(screenName))
            {
                return _screenColors[screenName];
            }
            else
            {               
                return ConsoleColor.White;
            }
        }

    }
}
