using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public class Elephant : GroundAnimal
{
    public Elephant(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Elephant {Name}");
    }
}