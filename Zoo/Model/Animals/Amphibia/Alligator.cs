using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal sealed class Alligator : AmphiniaAnimal
    {
        private readonly string Sound = "MmmmmmHeemmmmm";

        public Alligator()
        {
            AnimalType = AnimalType.Alligator;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tAlligator make sound {Sound}");
        }
    }
}
