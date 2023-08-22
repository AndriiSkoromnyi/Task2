using System.Drawing;

using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Settings interface.
    /// </summary>
    public interface ISettings
    {
        #region Interface Members

        /// <summary>
        /// Version of settings.
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// List of cats.
        /// </summary>
        List<ICat> Cats { get; set; }

        /// <summary>
        /// Color of the home screen.
        /// </summary>
        Color HomeScreenColor { get; set; }

        /// <summary>
        /// Color of the animals screen.
        /// </summary>
        Color AnimalsScreenColor { get; set; }

        /// <summary>
        /// Color of the mammals screen.
        /// </summary>
        Color MammalsScreenColor { get; set; }

        /// <summary>
        /// Color of the dogs screen.
        /// </summary>
        Color DogsScreenColor { get; set; }

        /// <summary>
        /// Color of the horses screen.
        /// </summary>
        Color HorsesScreenColor { get; set; }

        /// <summary>
        /// Color of the rabbits screen.
        /// </summary>
        Color RabbitsScreenColor { get; set; }

        #endregion // Interface Members

        /// <summary>
        /// Text color for the home screen.
        /// </summary>
        Color HomeScreenTextColor { get; set; }

        /// <summary>
        /// Text color for the animals screen.
        /// </summary>
        Color AnimalsScreenTextColor { get; set; }

        /// <summary>
        /// Text color for the mammals screen.
        /// </summary>
        Color MammalsScreenTextColor { get; set; }

        /// <summary>
        /// Text color for the dogs screen.
        /// </summary>
        Color DogsScreenTextColor { get; set; }

    }
}
