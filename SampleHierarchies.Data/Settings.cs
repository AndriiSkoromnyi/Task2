using System.Collections.Generic;
using System.Drawing;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings class.
    /// </summary>
    public class Settings : ISettings
    {
        #region Properties

        /// <inheritdoc/>
        public string Version { get; set; }

        /// <inheritdoc/>
        public List<ICat> Cats { get; set; }

        /// <inheritdoc/>
        public Color HomeScreenColor { get; set; }

        /// <inheritdoc/>
        public Color AnimalsScreenColor { get; set; }

        /// <inheritdoc/>
        public Color MammalsScreenColor { get; set; }

        /// <inheritdoc/>
        public Color DogsScreenColor { get; set; }

        /// <inheritdoc/>
        public Color HorsesScreenColor { get; set; }

        /// <inheritdoc/>
        public Color RabbitsScreenColor { get; set; }

        #endregion // Properties

        /// <inheritdoc />
        public Color HomeScreenTextColor { get; set; }

        /// <inheritdoc />
        public Color AnimalsScreenTextColor { get; set; }

        /// <inheritdoc />
        public Color MammalsScreenTextColor { get; set; }

        /// <inheritdoc />
        public Color DogsScreenTextColor { get; set; }

        #region Constructor

        public Settings()
        {
            // Initialize the list of cats
            Cats = new List<ICat>();
        }

        #endregion // Constructor
    }
}
