using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal sealed class Shark : SeaCreatureAnimal
    {
        private readonly string Sound = "Sharkkkkkk";

        public Shark()
        {
            AnimalType = AnimalType.Shark;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tShark make sound {Sound}");
        }
    }
}
