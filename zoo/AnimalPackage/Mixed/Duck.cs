using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public class Duck : MixedAnimal
{
    public Duck(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Duck {Name}");
    }
}