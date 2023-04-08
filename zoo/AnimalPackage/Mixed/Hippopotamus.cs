using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public class Hippopotamus : MixedAnimal
{
    public Hippopotamus(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Hippopotamus {Name}");
    }
}