using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Giraffe : LandAnimal
    {
        private readonly string Sound = "sheeeeee";

        public Giraffe()
        {
            AnimalType = AnimalType.Giraffe;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tGiraffe make sound {Sound}");
        }
    }
}
