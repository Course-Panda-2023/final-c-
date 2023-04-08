using zoo.TimePackage;
using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.WorkerPackage;


public delegate void WorkNotificationEventHandler(Worker worker);


public abstract class Worker : ITimeSubscriber
{
    public event WorkNotificationEventHandler? OnStart; 
    public event WorkNotificationEventHandler? OnEnd;
    
    public readonly string Name;
    protected readonly LogMessage _logger;

    protected Worker(string name, LogMessage logger)
    {
        Name = name;
        _logger = logger;
    }

    public abstract void OnTimeStamp(int time);

    protected void OnWorkStart()
    {
        OnStart?.Invoke(this);
    }
    
    protected void OnWorkEnd()
    {
        OnEnd?.Invoke(this);
    }

    public abstract AreaType? GetWorkingArea();

    public abstract int GetWorkTime();
}