using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Bird
{
    internal class Vulture : BirdAnimal
    {
        private readonly string Sound = "TTeeeeeee";

        public Vulture()
        {
            AnimalType = ZooAnimalType.Vulture;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tVulture make sound {Sound}");
        }
    }
}