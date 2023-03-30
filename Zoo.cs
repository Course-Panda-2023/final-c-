
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

class Zoo
{
    const int NUM_AREAS = 4;
    const int DAYTIME = 120;
    private int Income;
    List<Animal> Animals = new List<Animal>();
    List<Visitor> Visitors = new List<Visitor>();
    List<Cleaner> Cleaners = new List<Cleaner>();
    List<Doctor> Doctors = new List<Doctor>();
    List<Feeder> Feeders = new List<Feeder>();
    List<Tour> OngoingTours = new List<Tour>();
    static Manager Manager = Manager.CreateInstance;
    public event WorkStatus? StatusEvent;
    static List<Area> areas = new List<Area>();

    
    private Zoo(List<Animal> animals, List<Visitor> visitors, List<Cleaner> cleaners, List<Doctor> doctors, List<Feeder> feeders)
    {
        this.Animals = animals;
        this.Visitors = visitors;
        this.Cleaners = cleaners;
        this.Doctors = doctors;
        this.Feeders = feeders; 
        this.Income = 0;
    }

    private static bool IsZooValid(List<Animal> animals)
    {
        int landCount = 0;
        int skyCount = 0;
        int seaCount = 0;
        int mixedCount = 0;

        List<string> names = new List<string>();
        foreach (Animal animal in animals) 
        {
            string name = animal.GetName();
            if (names.Contains(name))
            {
                Manager.AddReport($"Animal {name} appears more than once in the list.");
                return false;
            }
                
            names.Add(name);
            
            switch(animal.GetArea())
            {
                case Area.Land:
                    landCount++;
                    break;
                case Area.Sky:
                    skyCount++;
                    break;
                case Area.Sea:
                    seaCount++;
                    break;
                case Area.MixedTerrain:
                    mixedCount++;
                    break;
            }
        }
        if (landCount >= 3 && skyCount >= 3 && seaCount >= 3 && mixedCount >= 3)
            return true;
        else
        {
            Manager.AddReport("Not enough animals from some category");
            return false;
        }
    }

    public static Zoo? CreateZoo(List<Animal> animals, List<Visitor> visitors, List<Cleaner> cleaners, List<Doctor> doctors, List<Feeder> feeders)
    {
        if (IsZooValid(animals))
            return new Zoo(animals, visitors, cleaners, doctors, feeders);
        return null;
    }

    // change interval maybe
    private Dictionary<int, List<Tuple<Worker, Area, string>>> HandleWorkerHours(bool BonusMode)
    {
        Dictionary<int, List<Tuple<Worker, Area, string>>> workerHours = new Dictionary<int, List<Tuple<Worker, Area, string>>>();
          
        int intervalPoints;  
        int workingTime;
        int time;
        int numberOfWorkingTimes = BonusMode? 2 : Enum.GetValues(typeof(Area)).Length;
        Area area;
        Random rand = new Random();
        List<Worker> workers = new List<Worker>();
        
        workers.AddRange(this.Cleaners);
        workers.AddRange(this.Doctors);
        workers.AddRange(this.Feeders);

        for(int i=0; i<workers.Count; i++)
        {
            Worker worker = workers[i];
            if (i < this.Cleaners.Count)
                workingTime = 2;
            else if(i >= this.Cleaners.Count && i < this.Cleaners.Count + this.Doctors.Count)
                workingTime = 5;
            else
                workingTime = 10;
            intervalPoints = DAYTIME / workingTime;
            
            List<int> times = Enumerable.Range(0, intervalPoints-1).OrderBy(t => rand.Next()).Take(numberOfWorkingTimes).ToList(); // take 2 or 4 random (according to BonusMode)
            times = times.Select(r=> r * workingTime).ToList();

            areas = Enum.GetValues(typeof(Area)).Cast<Area>().OrderBy(a => rand.Next()).ToList(); // Assign random areas to random times
            for(int j = 0; j < numberOfWorkingTimes; j++)
            {
                time = times[j];
                area = areas[j];
                
                // add started times
                if (!workerHours.ContainsKey(time))
                    workerHours.Add(time, new List<Tuple<Worker, Area, string>>());
                workerHours[time].Add(new Tuple<Worker, Area, string>(worker, area, "started"));
                
                // add finished times
                if (!workerHours.ContainsKey(time + workingTime))
                    workerHours.Add(time + workingTime, new List<Tuple<Worker, Area, string>>());
                workerHours[time + workingTime].Add(new Tuple<Worker, Area, string>(worker, area, "finished"));
            }

            // sort that "finished" statuses come before "started" statuses
            foreach (int timeidx in workerHours.Keys)  
            {
                workerHours[timeidx] = workerHours[timeidx].OrderBy(x => x.Item3).ToList();
            }
        }   
        return workerHours;
    }


    public delegate void WorkStatus(Worker worker, Area area, string status);

    private static void PrintStatusWork(Worker worker, Area area, string status)
    {
        Manager.AddReport($"Worker {worker.GetName()} {status} working in {area}");
    }

    private void PauseToursInArea(Area area)
    {
        foreach(Tour tour in this.OngoingTours)
        {
            if (tour.Area == area && tour.IsOngoing)
                tour.StopTour();
        }
    }

    private bool IsStoppingWorkerInArea(Area area)
    {
        List<Worker> stoppingWorkers = new List<Worker>();
        
        stoppingWorkers.AddRange(this.Doctors);
        stoppingWorkers.AddRange(this.Cleaners);
        foreach(Worker stoppingWorker in stoppingWorkers)
        {
            if (stoppingWorker.Area == area)
                return true;
        }
        return false;
    }

    private void ResumeTours()
    {
        Dictionary<Area, bool> freeAreas = new Dictionary<Area, bool>();
        foreach(Area area in areas)
            freeAreas[area] = !IsStoppingWorkerInArea(area);

        foreach(Tour tour in this.OngoingTours)
        {
            if ((!tour.IsOngoing && freeAreas[tour.Area]) || tour.IsFinished)
                tour.ResumeTour();
        }
    }

    private int AreaTicketFee(Area area)
    {
        const int NormalTicketFee = 50;
        List<Worker> workers = new List<Worker>();
        
        workers.AddRange(this.Doctors);
        workers.AddRange(this.Cleaners);
        workers.AddRange(this.Feeders);
        
        int WorkerPresentTicketFee = 0;
        foreach(Worker worker in workers)
        {
            if (worker.Area == area)
                WorkerPresentTicketFee = Math.Max(WorkerPresentTicketFee, worker.WorkerTicketFee);
        }
        return WorkerPresentTicketFee == 0? NormalTicketFee : WorkerPresentTicketFee;
    }
    public void CreateTour(Area area)
    {
        Random rand = new Random();
        int NUM_OF_VISITORS = rand.Next(4,7);

        List<Visitor> visitors = new List<Visitor>();
        for(int i=0; i<NUM_OF_VISITORS; i++)
            visitors.Add(new Visitor($"Visitor{i+1}"));
        Tour tour = new Tour(new List<Visitor>(), area, Manager);
        this.OngoingTours.Add(tour);
        tour.thread.Start();
        if (IsStoppingWorkerInArea(area))
        {
            Thread.Sleep(50);
            tour.StopTour();
        }
        this.Income += visitors.Count*AreaTicketFee(area);
    }
    private void TryCreateTour()
    {
        Random rand = new Random();
        Area area = (Area)areas[rand.Next(areas.Count)];

        Dictionary<Area, int> areaCounter = new Dictionary<Area, int>();
        foreach (Area areaC in areas)
            areaCounter[areaC] = 0;
        
        foreach(Tour tour in this.OngoingTours)
            areaCounter[tour.Area]++;
        
        if (!(areaCounter[area] >= 2
            || (area == Area.Land && (areaCounter[Area.Sky] > 0 || areaCounter[Area.Sea] > 0))
            || (area == Area.Sky && (areaCounter[Area.MixedTerrain] > 0 || areaCounter[Area.Land] > 0))
            || (area == Area.Sea && areaCounter[Area.Land] > 0
            || area == Area.MixedTerrain && areaCounter[Area.Sky] > 0)
            ))  
        {
            CreateTour(area);
        }
    }

    private void RemoveFinishedTours()
    {
        List<Tour> RemoveTours = new List<Tour>();
        foreach(Tour tour in this.OngoingTours)
        {
            if (tour.IsFinished)
                RemoveTours.Add(tour);
        }
        foreach(Tour tour in RemoveTours)
            this.OngoingTours.Remove(tour);

    }

    private void PromptWorkerStatus(Tuple<Worker, Area, string> workerAreaAndStatus)
    {
        Worker worker = workerAreaAndStatus.Item1;
        Area area = workerAreaAndStatus.Item2;
        string status = workerAreaAndStatus.Item3;
        if (status == "started")
        {
            this.StatusEvent?.Invoke(worker, area, status);
            worker.ChangeArea(area);
            if (worker is AnimalWorker)
            {
                AnimalWorker animalWorker = ((AnimalWorker)worker);
                animalWorker.FindAnimal(this.Animals, area);
            }
            if (worker is Cleaner || worker is Doctor)
                PauseToursInArea(area);
        }
        else if(status == "finished")
        {
            worker.ChangeArea(null);
            if (worker is AnimalWorker)
            {
                AnimalWorker animalWorker = ((AnimalWorker)worker);
                animalWorker.UntreatAnimal();
            }
            this.StatusEvent?.Invoke(worker, area, status);
        }
    }

    public void RunDay(bool BonusMode)
    {
        Dictionary<int, List<Tuple<Worker, Area, string>>> workerHours = HandleWorkerHours(BonusMode);
        this.StatusEvent += PrintStatusWork;
        for(int i=0; i<DAYTIME; i++)
        {
            Manager.AddReport($"Second {i+1} now");
            if (workerHours.ContainsKey(i))
            {
                foreach (Tuple<Worker, Area, string> workerAreaAndStatus in workerHours[i])
                {
                    PromptWorkerStatus(workerAreaAndStatus);
                }
            }
            RemoveFinishedTours();
            ResumeTours();
            TryCreateTour();

            Thread.Sleep(100);
            Manager.AddReport("");
        }

        // wait for all tours to end before calling it a day 
        foreach(Tour tour in this.OngoingTours)
            tour.thread.Join();
        
        Manager.AddReport($"Total income today: {this.Income}");
    }
}