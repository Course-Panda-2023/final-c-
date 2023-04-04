using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Bird
{
    internal class Owl : BirdAnimal
    {
        private readonly string Sound = "CheeCheee";

        public Owl()
        {
            AnimalType = ZooAnimalType.Owl;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tOwl make sound {Sound}");
        }
    }
}