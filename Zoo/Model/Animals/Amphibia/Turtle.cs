using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Amphibia
{
    internal class Turtle : AmphiniaAnimal
    {
        private readonly string Sound = "NinjaTurtle";

        public Turtle()
        {
            AnimalType = ZooAnimalType.Turtle;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tTurtle make sound {Sound}");
        }
    }
}
