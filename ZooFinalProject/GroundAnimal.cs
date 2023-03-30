namespace ZooFinalProject
{
    public class GroundAnimal : Animal
    {
        public GroundAnimal(string name, string sound, Location location) : base(name, sound, location)
        {
        }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name} makes a sound: {Sound}");
        }
    }

}