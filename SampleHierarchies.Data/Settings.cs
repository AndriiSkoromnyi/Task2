using System.Drawing;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System.Collections.Generic;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings class.
    /// </summary>
    public class Settings : ISettings
    {
        #region Properties

        public Color MainScreenColor { get; set; }

        public Color AnimalsScreenColor { get; set; }

        public Color MammalsScreenColor { get; set; }

        public Color DogsScreenColor { get; set; }

        public Color HorsesScreenColor { get; set; }

        public Color RabbitsScreenColor { get; set; }

        #endregion // Properties

        #region Text Color Properties

        public Color MainScreenTextColor { get; set; }

        public Color AnimalsScreenTextColor { get; set; }

        public Color MammalsScreenTextColor { get; set; }

        public Color DogsScreenTextColor { get; set; }

        #endregion // Text Color Properties

        #region New Properties

        public ConsoleColor _mainScreenForegroundColor { get; set; } = ConsoleColor.Red;

        public ConsoleColor _animalScreenForegroundColor { get; set; } = ConsoleColor.Green;

        public ConsoleColor _mammalScreenForegroundColor { get; set; } = ConsoleColor.Blue;

        public ConsoleColor _dogScreenForegroundColor { get; set; } = ConsoleColor.Yellow;

        #endregion // New Properties

        #region Constructor

        public Settings()
        {
            
            // Set default colors or handle them in a more appropriate way
            MainScreenColor = Color.White;
            AnimalsScreenColor = Color.Black;
            MammalsScreenColor = Color.Gray;
            DogsScreenColor = Color.Brown;
            HorsesScreenColor = Color.DarkGray;
            RabbitsScreenColor = Color.LightGray;

            MainScreenTextColor = Color.Black;
            AnimalsScreenTextColor = Color.White;
            MammalsScreenTextColor = Color.White;
            DogsScreenTextColor = Color.Black;
        }

        #endregion // Constructor
    }
}
