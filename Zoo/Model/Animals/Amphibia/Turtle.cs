using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal sealed class Turtle : AmphiniaAnimal
    {
        private readonly string Sound = "NinjaTurtle";

        public Turtle()
        {
            AnimalType = AnimalType.Turtle;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tTurtle make sound {Sound}");
        }
    }
}
