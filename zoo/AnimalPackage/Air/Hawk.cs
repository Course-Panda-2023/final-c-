using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public class Hawk : AirAnimal
{
    public Hawk(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Hawk {Name}");
    }
}