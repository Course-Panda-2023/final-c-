using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal sealed class GoldFish : SeaCreatureAnimal
    {
        private readonly string Sound = "GlogGlog";

        public GoldFish()
        {
            AnimalType = AnimalType.GoldFish;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tGoldFish make sound {Sound}");
        }
    }
}
