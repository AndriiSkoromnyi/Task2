using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Runtime;


namespace SampleHierarchies.Services
{
    public class SettingsService : ISettingsService
    {
        private ISettings _settings;
        public ISettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public ISettings Read(string jsonPath)
        {
            ISettings? result = null;

            try
            {
                string jsonData = File.ReadAllText(jsonPath);
                result = JsonConvert.DeserializeObject<Settings>(jsonData); // Assuming Settings is the implementation of ISettings
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
    }
}
