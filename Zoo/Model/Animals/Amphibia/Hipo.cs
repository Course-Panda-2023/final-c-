using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal class Hipo : AmphiniaAnimal
    {
        private readonly string Sound = "eeeYOOYoooooO";

        public Hipo()
        {
            AnimalType = AnimalType.Hipo;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tHipo make sound {Sound}");
        }
    }
}
