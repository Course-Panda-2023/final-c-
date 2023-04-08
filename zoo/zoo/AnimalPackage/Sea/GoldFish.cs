using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;

public class GoldFish : SeaAnimal
{
    public GoldFish(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Goldfish {Name}");
    }
}