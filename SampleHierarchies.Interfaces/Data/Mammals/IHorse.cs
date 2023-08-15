namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a dog.
/// </summary>
public interface IHorse : IMammal
{
    #region Interface Members
    /// <summary>
    /// Breed of dog.
    /// </summary>
    string Breed { get; set; }
    string Color { get; set; }
    int Weight { get; set; }
    string TypeOfHorse { get; set; }
    #endregion // Interface Members
}
