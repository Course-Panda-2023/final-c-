using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public class Turtle : MixedAnimal
{
    public Turtle(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void MakeSound()
    {
        _logger($"Turtle {Name}");
    }
}