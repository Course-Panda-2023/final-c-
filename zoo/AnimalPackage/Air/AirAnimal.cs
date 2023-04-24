using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Air;

public abstract class AirAnimal : Animal
{
    protected AirAnimal(string name, LogMessage logger) : base(name, AreaType.AIR, logger)
    {
        
    }
}