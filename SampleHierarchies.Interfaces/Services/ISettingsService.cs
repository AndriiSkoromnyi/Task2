using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services
{
    public interface ISettingsService
    {
        // Метод для чтения данных о настройках из файла JSON
        ISettings? Read(string jsonPath);

        // Метод для записи данных о настройках в файл JSON
        void Write(ISettings settings, string jsonPath);
    }
}
