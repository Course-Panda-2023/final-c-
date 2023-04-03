using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal class Shark : SeaCreatureAnimal
    {
        private readonly string Sound = "Sharkkkkkk";

        public Shark()
        {
            AnimalType = ZooAnimalType.Shark;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tShark make sound {Sound}");
        }
    }
}
