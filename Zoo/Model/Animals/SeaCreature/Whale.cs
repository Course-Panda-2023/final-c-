using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal sealed class Whale : SeaCreatureAnimal
    {
        private readonly string Sound = "JOOOJOJoso";

        public Whale()
        {
            AnimalType = AnimalType.Whale;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tWhale make sound {Sound}");
        }
    }
}
