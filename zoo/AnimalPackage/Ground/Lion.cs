using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public class Lion : GroundAnimal
{
    public Lion(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Lion {Name}");
    }
}