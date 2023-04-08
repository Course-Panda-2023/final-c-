using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Ground;

public abstract class GroundAnimal : Animal
{
    protected GroundAnimal(string name, LogMessage logger) : base(name, AreaType.GROUND, logger)
    {
        
    }
}