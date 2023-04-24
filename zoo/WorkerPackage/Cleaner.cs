using zoo.Area;
using zoo.ManagerPackage;

namespace zoo.WorkerPackage;


public class Cleaner : Worker
{
    private int _workStartTime;
    private AreaType? _area;
    private bool _currentlyWorking = false;

    public Cleaner(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public void Clean(AreaType area, int time)
    {
        _logger($"{Name} is cleaning the area {area}");
        _workStartTime = time;
        _area = area;
        _currentlyWorking = true;
        
        this.OnWorkStart();
    }

    public override void OnTimeStamp(int time)
    {
        if (_currentlyWorking)
        {
            if (time - _workStartTime == GetWorkTime())
            {
                _logger($"{Name} finished cleaning the area {_area}");
                _area = null;
                _currentlyWorking = false;
            
                this.OnWorkEnd();
            }
        }
    }

    public override AreaType? GetWorkingArea()
    {
        return _area;
    }

    public override int GetWorkTime()
    {
        return 2;
    }

    public override bool IsCurrentlyWorking()
    {
        return _currentlyWorking;
    }
}