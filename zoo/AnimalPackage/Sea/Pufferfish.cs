using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;

public class Pufferfish : SeaAnimal
{
    public Pufferfish(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Pufferfish {Name}");
    }
}