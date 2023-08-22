using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings class.
    /// </summary>
    public class Settings : ISettings
    {

        #region Properties

        public ConsoleColor _mainScreenForegroundColor { get; set; } = ConsoleColor.Red;

        public ConsoleColor _animalScreenForegroundColor { get; set; } = ConsoleColor.Green;

        public ConsoleColor _mammalScreenForegroundColor { get; set; } = ConsoleColor.Blue;

        public ConsoleColor _dogScreenForegroundColor { get; set; } = ConsoleColor.Yellow;

        public ConsoleColor _catScreenForegroundColor { get; set; } = ConsoleColor.DarkYellow;

        public ConsoleColor _rabbitScreenForegroundColor { get; set; } = ConsoleColor.Cyan;

        public ConsoleColor _horseScreenForegroundColor { get; set; } = ConsoleColor.Magenta;

        #endregion // Properties

    }
}
