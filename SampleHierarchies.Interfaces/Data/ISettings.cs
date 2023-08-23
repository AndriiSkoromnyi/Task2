using System.Drawing;

using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Settings interface.
    /// </summary>
    public interface ISettings
    {
        ConsoleColor _mainScreenForegroundColor { get; set; }
    }
}