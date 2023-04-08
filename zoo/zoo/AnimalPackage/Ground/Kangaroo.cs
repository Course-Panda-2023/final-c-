using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public class Kangaroo : GroundAnimal
{
    public Kangaroo(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Kangaroo {Name}");
    }
}