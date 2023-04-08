using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;


public class Shark : SeaAnimal
{
    public Shark(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Shark {Name}");
    }
}