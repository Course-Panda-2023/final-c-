using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Zebra : LandAnimal
    {
        private readonly string Sound = "HeyyaaZeeee";

        public Zebra()
        {
            AnimalType = ZooAnimalType.Zebra;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tZebra makes sound {Sound}");
        }
    }
}
