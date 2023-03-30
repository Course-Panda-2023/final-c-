using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Amphibia
{
    internal class Frog : AmphiniaAnimal
    {
        private readonly string Sound = "RabikRabik";

        public Frog()
        {
            AnimalType = ZooAnimalType.Frog;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tFrog make sound {Sound}");
        }
    }
}
