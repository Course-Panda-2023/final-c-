using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal class Duck : AmphiniaAnimal
    {
        private readonly string Sound = "KwakKwhakKwhak";

        public Duck()
        {
            AnimalType = ZooAnimalType.Duck;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tDuck make sound {Sound}");
        }
    }
}
