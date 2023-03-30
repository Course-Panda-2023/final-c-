namespace ZooFinalProject
{
    public class SeaAnimal : Animal
    {
        public SeaAnimal(string name, string sound, Location location) : base(name, sound, location)
        {
        }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name} makes a sound: {Sound}");
        }
    }

}
