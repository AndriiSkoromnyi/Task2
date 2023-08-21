using System.Drawing;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services
{
    public interface ISettingsService
    {
        Color MainScreenTextColor { get; set; }
        ISettings Settings { get; set; } // Existing property
        ISettings _settings { get; set; } // New property
        void ChangeTextColors(ConsoleColor textColor);
        ISettings? Read(string jsonPath);
        void Write(ISettings settings, string jsonPath);
    }
}
