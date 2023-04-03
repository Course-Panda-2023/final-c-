using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Elephant : LandAnimal
    {
        private readonly string Sound = "Yhooooo";

        public Elephant()
        {
            AnimalType = ZooAnimalType.Elephant;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tElephant make sound {Sound}");
        }
    }
}
