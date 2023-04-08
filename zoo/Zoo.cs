using zoo.Area;
using zoo.TimePackage;
using zoo.AnimalPackage;
using zoo.ManagerPackage;
using zoo.WorkerPackage;

namespace zoo;


public class Zoo : ITimeSubscriber
{
    private readonly IEnumerable<Animal> _animals;
    private readonly IEnumerable<Worker> _workers;
    private readonly int _daytime;
    private readonly AreaType[] _areas;

    private readonly IDictionary<Worker, IDictionary<AreaType, int>> _workersSchedule =
        new Dictionary<Worker, IDictionary<AreaType, int>>();

    private readonly IDictionary<AreaType, List<Tour>> _tours = new Dictionary<AreaType, List<Tour>>();
    private readonly LogMessage _logger;

    public Zoo(IEnumerable<Animal> animals, IEnumerable<Worker> workers, int daytime, AreaType[] areas, LogMessage logger)
    {
        Dictionary<AreaType, int> typeCount = new Dictionary<AreaType, int>();
        foreach (AreaType area in areas)
        {
            typeCount[area] = 0;
            _tours[area] = new List<Tour>();
        }

        foreach (Animal animal in animals)
        {
            typeCount[animal.Area] += 1;
        }

        foreach (int count in typeCount.Values)
        {
            if (count < 3)
            {
                throw new Exception("Error: there are not 3 animals from each type");
            }
        }
        
        _animals = animals;
        _workers = workers;
        _daytime = daytime;
        _areas = areas;
        _logger = logger;
        
        SetWorkersSchedule(day:0);
    }

    private void SetWorkersSchedule(int day)
    {
        foreach (Worker worker in _workers)
        {
            int[] uniqueRandomNumbers = Utils.GenerateUniqueRandomNumbers(1, _daytime - worker.GetWorkTime(), _areas.Length).ToArray();
            int[] areasShuffle = Utils.GenerateUniqueRandomNumbers(0, _areas.Length-1, _areas.Length).ToArray();

            _workersSchedule[worker] = new Dictionary<AreaType, int>();

            for (int i = 0; i < _areas.Length; i++)
            {
                _workersSchedule[worker][_areas[areasShuffle[i]]] = day * _daytime + uniqueRandomNumbers[i];
                
                _logger($"{worker.Name} works in area {_areas[areasShuffle[i]]} at time {_workersSchedule[worker][_areas[areasShuffle[i]]]}");
            }
        }
    }

    private List<Tour> GetActiveToursInArea(AreaType area)
    {
        return _tours[area].FindAll(t => !t.HasFinished);
    }

    private bool CanTourStart(Tour tour)
    {
        if (GetActiveToursInArea(tour.Area).Count >= 2)
        {
            return false;
        }

        Dictionary<AreaType, List<AreaType>> forbiddenCombinations = new Dictionary<AreaType, List<AreaType>>
        {
            { AreaType.GROUND, new List<AreaType> { AreaType.AIR , AreaType.SEA} },
            { AreaType.AIR , new List<AreaType> { AreaType.MIXED }},
            { AreaType.SEA , new List<AreaType>()},
            { AreaType.MIXED , new List<AreaType>()}
        };

        foreach (AreaType area in _areas)
        {
            if (GetActiveToursInArea(area).Count > 0)
            {
                if (forbiddenCombinations[tour.Area].Contains(area))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private Animal ShuffleAnimal(AreaType area)
    {
        List<Animal> relevantAnimals = _animals.Where(animal => animal.Area == area).ToList();
        Random r = new Random();

        while (true)
        {
            Animal animal = relevantAnimals[r.Next(0, relevantAnimals.Count)];

            if (! animal.IsBeingThreaten())
            {
                return animal;
            }
        }
    }

    public void OnTimeStamp(int time)
    {
        Tour tour = new Tour(areas:_areas, logger:_logger);

        if (CanTourStart(tour))
        {
            _tours[tour.Area].Add(tour);

            foreach (Worker worker in _workers)
            {
                worker.OnStart += tour.OnWorkerStart;
                worker.OnEnd += tour.OnWorkerEnd;
            }
            
            new Thread(() =>
            {
                tour.Start(time);
            }).Start();
        }
        else
        {
            _logger($"Tour that should've started in area {tour.Area} couldn't be launched");
        }

        foreach (AreaType area in _areas)
        {
            foreach (Tour t in GetActiveToursInArea(area))
            {
                new Thread(() =>
                {
                    t.OnTimeStamp(time);
                }).Start();
            }
        }

        foreach (Worker worker in _workers)
        {
            foreach (AreaType area in _areas)
            {
                if (_workersSchedule[worker][area] == time)
                {
                    // worker should start to work now in that area
                    if (worker is AnimalTherapist)
                    {
                        new Thread(() => ((AnimalTherapist) worker).Treat(ShuffleAnimal(area), time)).Start();
                    }
                    else
                    {
                        // worker is a Cleaner
                        new Thread(() => ((Cleaner) worker).Clean(area, time)).Start();
                    }
                }
            }
        }

        if (time % _daytime == 0)
        {
            // a day has been passed, set the next day schedule for the workers
            SetWorkersSchedule(day:time/_daytime);
        }
    }
}