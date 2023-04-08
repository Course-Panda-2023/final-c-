using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public class Alligator : MixedAnimal
{
    public Alligator(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Alligator {Name}");
    }
}