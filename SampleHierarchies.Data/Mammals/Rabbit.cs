using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Very basic rabbit class.
    /// </summary>
    public class Rabbit : MammalBase, IRabbit
    {
        #region Public Methods

        
        public override void Display()
        
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} , My weight is: {Weight} kg, I am a {TypeOfRabbit}, also I love {Food}");
            
            Console.WriteLine((HasOwner? "Yes, I have an owner" : "No, I don't have an owner" ));


            
        }

        
       

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is IRabbit rabbit)
            {
                base.Copy(animal);
                //Breed = rabbit.Breed;
                //Color = rabbit.Color;
                TypeOfRabbit = rabbit.TypeOfRabbit;
                HasOwner = rabbit.HasOwner;
            }
        }


        
        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        //public string Breed { get; set; }
        //public string Color { get; set; }
        public int Weight { get; set; }
        public string TypeOfRabbit { get; set; }
        public bool HasOwner { get; set; }
        public string Food { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="breed">Breed</param>
        /// <param name="color">Color</param>
        /// <param name="weight">Weight</param>
        /// <param name="typeOfRabbit">Type of rabbit</param>
        /// 

        public Rabbit(string name, int age,  int weight, string typeOfRabbit, bool hasOwner, string food) : base(name, age, MammalSpecies.Rabbit)
        {
            //Breed = breed;
            //Color = color;
            Weight = weight;
            TypeOfRabbit = typeOfRabbit;
            HasOwner = hasOwner;
            Food = food;
        }

        #endregion // Ctors And Properties
    }
}
