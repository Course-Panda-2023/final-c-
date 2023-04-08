using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public class Frog : MixedAnimal
{
    public Frog(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Frog {Name}");
    }
}