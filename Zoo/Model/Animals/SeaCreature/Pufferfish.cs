using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal class PufferFish : SeaCreatureAnimal
    {
        private readonly string Sound = "Kooookkoko";

        public PufferFish()
        {
            AnimalType = ZooAnimalType.Pufferfish;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tPufferFish make sound {Sound}");
        }
    }
}
