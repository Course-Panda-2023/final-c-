using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public class Giraffe : GroundAnimal
{
    public Giraffe(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Giraffe {Name}");
    }
}