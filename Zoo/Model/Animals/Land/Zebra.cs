using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Land
{
    internal sealed class Zebra : LandAnimal
    {
        private readonly string Sound = "HeyyaaZeeee";

        public Zebra()
        {
            AnimalType = AnimalType.Zebra;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tZebra makes sound {Sound}");
        }
    }
}
