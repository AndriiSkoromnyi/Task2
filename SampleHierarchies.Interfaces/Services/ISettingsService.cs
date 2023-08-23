using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services
{
    public interface ISettingsService
    {
        ISettings Settings { get; set; }
        ISettings Read(string jsonPath);
        void Write(ISettings settings, string jsonPath);
        
    }
}
