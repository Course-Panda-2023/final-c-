using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Bird
{
    internal sealed class Pelican : BirdAnimal
    {
        private readonly string Sound = "PeeeeKeee";

        public Pelican()
        {
            AnimalType = AnimalType.Pelican;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tPelican make sound {Sound}");
        }
    }
}