using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Very basic cat class.
    /// </summary>
    public class Cat : MammalBase, ICat
    {
        #region Public Methods


        public override void Display()

        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}, My weight is: {Weight} kg, I am a {Color}, also I love {FoodPreference}");

            Console.WriteLine((HasOwner ? "Yes, I have an owner" : "No, I don't have an owner"));
        }




        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is ICat cat)
            {
                base.Copy(animal);
                //Breed = cat.Breed;
                Color = cat.Color;
                
                HasOwner = cat.HasOwner;
            }
        }



        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        //public string Breed { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        //public string TypeOfCat { get; set; }
        public bool HasOwner { get; set; }
        public string FoodPreference { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// 
        /// <param name="color">Color</param>
        /// <param name="weight">Weight</param>
        /// <param name="typeOfCat">Type of cat</param>
        /// 

        public Cat(string name, int age, int weight, string color, bool hasOwner, string foodPreference) : base(name, age, MammalSpecies.Cat)
        {
            //Breed = breed;
            Color = color;
            Weight = weight;
            //TypeOfCat = typeOfCat;
            HasOwner = hasOwner;
            FoodPreference = foodPreference;
        }

        #endregion // Ctors And Properties
    }
}
