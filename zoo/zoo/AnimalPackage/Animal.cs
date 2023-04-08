using zoo.Area;
using zoo.ManagerPackage;
using zoo.WorkerPackage;

namespace zoo.AnimalPackage;


public abstract class Animal
{
    public readonly string Name;
    private object _lock = new object();
    private AnimalTherapist? _therapist = null;
    internal readonly AreaType Area;
    protected readonly LogMessage _logger;

    protected Animal(string name, AreaType area, LogMessage logger)
    {
        Name = name;
        Area = area;
        _logger = logger;
    }
    
    public abstract void MakeSound();

    internal void SetTherapist(AnimalTherapist? therapist)
    {
        lock (_lock)
        {
            _therapist = therapist;
        }
    }

    internal bool IsBeingThreaten()
    {
        lock (_lock)
        {
            return _therapist != null;
        }
    }
}