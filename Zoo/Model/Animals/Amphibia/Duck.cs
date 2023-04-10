using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal sealed class Duck : AmphiniaAnimal
    {
        private readonly string Sound = "KwakKwhakKwhak";

        public Duck()
        {
            AnimalType = AnimalType.Duck;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tDuck make sound {Sound}");
        }
    }
}
