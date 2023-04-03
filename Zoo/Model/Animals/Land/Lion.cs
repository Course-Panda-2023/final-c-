using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Lion : LandAnimal
    {
        private readonly string Sound = "Whohahaha";

        public Lion()
        {
            AnimalType = ZooAnimalType.Lion;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tLion makes sound {Sound}");
        }
    }
}
