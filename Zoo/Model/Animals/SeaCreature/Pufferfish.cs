using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal sealed class PufferFish : SeaCreatureAnimal
    {
        private readonly string Sound = "Kooookkoko";

        public PufferFish()
        {
            AnimalType = AnimalType.Pufferfish;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tPufferFish make sound {Sound}");
        }
    }
}
