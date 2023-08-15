using Newtonsoft.Json;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.IO;

namespace SampleHierarchies.Services
{
    public class SettingsService : ISettingsService
    {
        public ISettings? Read(string jsonPath)
        {
            ISettings? result = null;
            // TODO: Реализуйте чтение данных из файла JSON и возврат объекта ISettings
            // Примерно так:
            string jsonData = File.ReadAllText(jsonPath);
            result = JsonConvert.DeserializeObject<ISettings>(jsonData);
            return result;
        }

        public void Write(ISettings settings, string jsonPath)
        {
            try
            {
                // Преобразуем объект ISettings в JSON-строку
                string jsonData = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);

                // Записываем JSON-строку в файл
                File.WriteAllText(jsonPath, jsonData);
            }
            catch (Exception ex)
            {
                // В случае ошибки при записи выводим сообщение об ошибке
                Console.WriteLine("Error while writing to JSON file: " + ex.Message);
            }
        }
    }
}
