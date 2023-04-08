using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public class Vulture : AirAnimal
{
    public Vulture(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Vulture {Name}");
    }
}