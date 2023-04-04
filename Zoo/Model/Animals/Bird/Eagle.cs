using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Bird
{
    internal class Eagle : BirdAnimal
    {
        private readonly string Sound = "WeeewweewWee";

        public Eagle()
        {
            AnimalType = AnimalType.Eagle;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tEagle make sound {Sound}");
        }
    }
}