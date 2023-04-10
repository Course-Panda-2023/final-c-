using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal sealed class Frog : AmphiniaAnimal
    {
        private readonly string Sound = "RabikRabik";

        public Frog()
        {
            AnimalType = AnimalType.Frog;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tFrog make sound {Sound}");
        }
    }
}
