using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.SeaCreature
{
    internal class Whale : SeaCreatureAnimal
    {
        private readonly string Sound = "JOOOJOJoso";

        public Whale()
        {
            AnimalType = ZooAnimalType.Whale;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tWhale make sound {Sound}");
        }
    }
}
