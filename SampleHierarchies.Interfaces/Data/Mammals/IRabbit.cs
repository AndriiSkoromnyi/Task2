namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a dog.
/// </summary>
public interface IRabbit : IMammal
{
    #region Interface Members
    /// <summary>
    /// Breed of rabbit.
    /// </summary>
    
    
    int Weight { get; set; }
    string TypeOfRabbit { get; set; }
    bool HasOwner { get; set; }
    #endregion // Interface Members
}
