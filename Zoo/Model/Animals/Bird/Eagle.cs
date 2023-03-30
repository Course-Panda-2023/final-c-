using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Bird
{
    internal class Eagle : BirdAnimal
    {
        private readonly string Sound = "WeeewweewWee";

        public Eagle()
        {
            AnimalType = ZooAnimalType.Eagle;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tEagle make sound {Sound}");
        }
    }
}