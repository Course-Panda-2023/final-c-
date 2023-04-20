using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Bird
{
    internal sealed class Hawk : BirdAnimal
    {
        private readonly string Sound = "CheeCheee";

        public Hawk()
        {
            AnimalType = AnimalType.Hawk;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tHawk make sound {Sound}");
        }
    }
}