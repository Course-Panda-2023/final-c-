using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Bird
{
    internal class Hawk : BirdAnimal
    {
        private readonly string Sound = "CheeCheee";

        public Hawk()
        {
            AnimalType = ZooAnimalType.Hawk;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tHawk make sound {Sound}");
        }
    }
}