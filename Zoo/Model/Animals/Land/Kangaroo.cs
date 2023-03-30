using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Land
{
    internal class Kangaroo : LandAnimal
    {
        private readonly string Sound = "Kanggooooo";

        public Kangaroo()
        {
            AnimalType = ZooAnimalType.Kangaroo;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tKangaroo make sound {Sound}");
        }
    }
}
