using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public class Owl : AirAnimal
{
    public Owl(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Owl {Name}");
    }
}