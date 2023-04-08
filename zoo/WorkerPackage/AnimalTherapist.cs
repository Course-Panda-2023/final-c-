using zoo.AnimalPackage;
using zoo.ManagerPackage;

namespace zoo.WorkerPackage;


public abstract class AnimalTherapist : Worker
{
    protected AnimalTherapist(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public abstract void Treat(Animal animal, int time);
}