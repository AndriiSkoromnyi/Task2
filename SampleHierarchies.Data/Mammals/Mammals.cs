using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IHorse> Horses { get; set; }
    public List<IRabbit> Rabbits { get; set; }
    public List<ICat> Cats { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Horses = new List<IHorse>();
        Rabbits = new List<IRabbit>();
        Cats = new List<ICat>();
    }

    #endregion // Ctors
}
