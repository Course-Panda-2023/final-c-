using zoo.TimePackage;
using zoo.Area;
using zoo.ManagerPackage;
using zoo.WorkerPackage;

namespace zoo;


public class Tour : ITimeSubscriber
{
    public readonly AreaType Area;
    private int _startTime;
    private object _lock = new object();
    private readonly List<Worker> _areaWorkers = new List<Worker>();
    private int _timePassed = 0;
    public bool HasFinished = false;
    private readonly LogMessage _logger;
    
    public Tour(AreaType[] areas, LogMessage logger)
    {
        Random r = new Random();
        Area = areas[r.Next(0, areas.Length)];
        _logger = logger;
    }

    public void Start(int time)
    {
        _logger($"Tour started in area {Area}");
        _startTime = time;
    }

    public void OnTimeStamp(int time)
    {
        lock (_lock)
        {
            _timePassed += _areaWorkers.Count == 0 ? 1 : 0;
        }

        if (_timePassed == 10)
        {
            _logger($"Tour in area {Area} that started at time {_startTime} has ended");
            HasFinished = true;
        }
    }

    public void OnWorkerStart(Worker worker)
    {
        if (worker.GetWorkingArea() != Area)
        {
            return;
        }
        
        lock (_lock)
        {
            _areaWorkers.Add(worker);
            _logger($"Tour in area {Area} that started at time {_startTime} has paused");
        }
    }
    
    public void OnWorkerEnd(Worker worker)
    {
        if (worker.GetWorkingArea() != Area)
        {
            return;
        }
        
        lock (_lock)
        {
            _areaWorkers.Remove(worker);
            _logger($"Tour in area {Area} that started at time {_startTime} has continued");
        }
    }
}