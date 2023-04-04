using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Land
{
    internal class Kangaroo : LandAnimal
    {
        private readonly string Sound = "Kanggooooo";

        public Kangaroo()
        {
            AnimalType = AnimalType.Kangaroo;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tKangaroo make sound {Sound}");
        }
    }
}
