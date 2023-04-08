using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.AnimalPackage.Sea;

public abstract class SeaAnimal : Animal
{
    protected SeaAnimal(string name, LogMessage logger) : base(name, AreaType.SEA, logger)
    {
        
    }
}