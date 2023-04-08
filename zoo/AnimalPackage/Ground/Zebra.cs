using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public class Zebra : GroundAnimal
{
    public Zebra(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Zebra {Name}");
    }
}