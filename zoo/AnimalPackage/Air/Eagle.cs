using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public class Eagle : AirAnimal
{
    public Eagle(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Eagle {Name}");
    }
}