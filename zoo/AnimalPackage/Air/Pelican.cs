using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public class Pelican : AirAnimal
{
    public Pelican(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Pelican {Name}");
    }
}