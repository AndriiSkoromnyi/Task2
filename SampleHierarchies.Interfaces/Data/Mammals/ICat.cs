namespace SampleHierarchies.Interfaces.Data.Mammals
{
    /// <summary>
    /// Interface depicting a cat.
    /// </summary>
    public interface ICat : IMammal
    {
        #region Interface Members
        /// <summary>
        /// Breed of cat.
        /// </summary>

        int Weight { get; set; }
        string Color { get; set; }
        bool HasOwner { get; set; }

        #endregion // Interface Members
    }
}
