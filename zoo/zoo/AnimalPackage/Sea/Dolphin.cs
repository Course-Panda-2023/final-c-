using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;

public class Dolphin : SeaAnimal
{
    public Dolphin(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Dolphin {Name}");
    }
}