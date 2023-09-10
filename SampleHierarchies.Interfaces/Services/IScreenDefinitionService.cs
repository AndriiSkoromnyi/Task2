namespace SampleHierarchies.Interfaces.Services
{
    public interface IScreenDefinitionService
    {
        IScreenDefinitionService Load(string jsonFileName);
        bool Save(IScreenDefinitionService screenDefinition, string jsonFileName);
    }
}
