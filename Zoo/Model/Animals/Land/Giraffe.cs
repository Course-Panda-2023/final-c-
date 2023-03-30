using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Land
{
    internal class Giraffe : LandAnimal
    {
        private readonly string Sound = "sheeeeee";

        public Giraffe()
        {
            AnimalType = ZooAnimalType.Giraffe;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tGiraffe make sound {Sound}");
        }
    }
}
