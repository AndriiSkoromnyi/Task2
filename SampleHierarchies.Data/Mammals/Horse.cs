using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic dog class.
/// </summary>
public class Horse : MammalBase, IHorse
{
    #region Public Methods

    ///// <inheritdoc/>
    //public override void MakeSound()
    //{
    //    Console.WriteLine("My name is: {0} and I am making sound", Name);
    //}

    ///// <inheritdoc/>
    //public override void Move()
    //{
    //    Console.WriteLine("My name is: {0} and I am running", Name);
    //}

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a {Breed} horse, I am {Color} horse, My weight is: {Weight} kg, I am a {TypeOfHorse}");
    }


    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IHorse ad)
        {
            base.Copy(animal);
            Breed = ad.Breed;
            Color = ad.Color;
            TypeOfHorse = ad.TypeOfHorse;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Breed { get; set; }
    public string Color { get; set; }
    public int Weight { get; set; }
    public string TypeOfHorse { get; set; }
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name = "name" > Name </ param >
    /// < param name="age">Age</param>
    /// <param name = "breed" > Breed </ param >
    /// <param name = "color" > colore </ param >
    /// <param name = "weight" > colore </ param >
    /// <param name = "typeOfHorse" > colore </ param >


    public Horse (string name, int age, string breed, string color, int weight, string typeOfHorse) : base(name, age, MammalSpecies.Horse)
    {
        Breed = breed;
        Color = color;
        Weight = weight;
        TypeOfHorse = typeOfHorse;
    }

    #endregion // Ctors And Properties
}