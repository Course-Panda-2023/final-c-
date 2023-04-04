using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal class Dolphin : SeaCreatureAnimal
    {
        private readonly string Sound = "LogLOgggggoso";

        public Dolphin()
        {
            AnimalType = AnimalType.Dolphin;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tDolphin makes sound {Sound}");
        }
    }
}
