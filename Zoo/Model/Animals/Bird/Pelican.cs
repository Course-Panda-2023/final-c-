using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Bird
{
    internal class Pelican : BirdAnimal
    {
        private readonly string Sound = "PeeeeKeee";

        public Pelican()
        {
            AnimalType = ZooAnimalType.Pelican;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tPelican make sound {Sound}");
        }
    }
}