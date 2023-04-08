using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;


public class Whale : SeaAnimal
{
    public Whale(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Whale {Name}");
    }
}