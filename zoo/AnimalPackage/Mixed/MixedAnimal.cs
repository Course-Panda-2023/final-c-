using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Mixed;

public abstract class MixedAnimal : Animal
{
    protected MixedAnimal(string name, LogMessage logger) : base(name, AreaType.MIXED, logger)
    {
        
    }
}