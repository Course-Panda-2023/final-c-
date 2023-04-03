using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal class Alligator : AmphiniaAnimal
    {
        private readonly string Sound = "MmmmmmHeemmmmm";

        public Alligator()
        {
            AnimalType = ZooAnimalType.Alligator;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tAlligator make sound {Sound}");
        }
    }
}
