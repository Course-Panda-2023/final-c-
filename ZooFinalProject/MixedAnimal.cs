namespace ZooFinalProject
{
    public class MixedAnimal : Animal
    {
        public MixedAnimal(string name, string sound, Location location) : base(name, sound, location)
        {
        }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name} makes a sound: {Sound}");
        }
    }

}
