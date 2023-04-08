using zoo.Area;
using zoo.AnimalPackage;
using zoo.ManagerPackage;

namespace zoo.WorkerPackage;


public class Doctor : AnimalTherapist
{
    private int _workStartTime;
    private Animal? _animal;
    private bool _currentlyWorking = false;
    
    public Doctor(string name, LogMessage logger) : base(name, logger)
    {
        
    }
    
    public override void Treat(Animal animal, int time)
    {
        if (animal.IsBeingThreaten())
        {
            _logger($"Animal {animal.Name} can't be threaten by {Name} because it's already being threaten by another work");
        }
        else
        {
            _workStartTime = time;
            _animal = animal;
            _animal.SetTherapist(this);
            _currentlyWorking = true;

            _logger($"{Name} is treating the animal {_animal.Name}");
            _animal.MakeSound();
            
            this.OnWorkStart();
        }
    }

    public override void OnTimeStamp(int time)
    {
        if (_currentlyWorking)
        {
            if (time - _workStartTime == GetWorkTime())
            {
                _logger($"{Name} finished treating the animal {_animal?.Name}");
                _animal?.SetTherapist(null);
                _animal = null;
                _currentlyWorking = false;
            
                this.OnWorkEnd();
            }
        }
    }

    public override AreaType? GetWorkingArea()
    {
        return _animal?.Area;
    }

    public override int GetWorkTime()
    {
        return 5;
    }

    public override bool IsCurrentlyWorking()
    {
        return _currentlyWorking;
    }
}