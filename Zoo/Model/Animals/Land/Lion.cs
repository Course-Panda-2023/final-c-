using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Lion : LandAnimal
    {
        private readonly string Sound = "Whohahaha";

        public Lion()
        {
            AnimalType = AnimalType.Lion;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tLion makes sound {Sound}");
        }
    }
}
