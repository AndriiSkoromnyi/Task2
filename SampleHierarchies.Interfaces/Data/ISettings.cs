namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Settings interface.
    /// </summary>
    public interface ISettings
    {
        ConsoleColor _mainScreenForegroundColor { get; set; }

        ConsoleColor _animalScreenForegroundColor { get; set; } 

        ConsoleColor _mammalScreenForegroundColor { get; set; } 

        ConsoleColor _dogScreenForegroundColor { get; set; } 

        ConsoleColor _catScreenForegroundColor { get; set; } 

        ConsoleColor _rabbitScreenForegroundColor { get; set; } 

        ConsoleColor _horseScreenForegroundColor { get; set; }

    }
}