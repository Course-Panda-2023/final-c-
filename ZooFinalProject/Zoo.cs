using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ZooFinalProject
{
    public class Zoo
    {
        public List<Worker> Workers { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Visitor> Visitors { get; set; }

        public Queue<Tour> ScheduledTours { get; set; }
        public Queue<int> DelaysQueue { get; set; }
        public Queue<Visitor> VisitorsQueue { get; set; }

        public Dictionary<Worker, DateTime> WorkerArrivalTimes { get; set; }

        public delegate void WorkerDelegate(Worker worker, Location area, string status);
        public event WorkerDelegate StartWorking;

        private static Manager instance = null;
        private int VisitorCount = 0;

        private ProfessionBlock block = ProfessionBlock.None;
        private int Profit = 0;
        public static Manager ManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
        public Zoo()
        {
            // store all the people
            Workers = new List<Worker>();
            Animals = new List<Animal>();
            Visitors = new List<Visitor>();
            // store the events happening in the zoo
            ScheduledTours = new Queue<Tour>();
            DelaysQueue= new Queue<int>();
            VisitorsQueue = new Queue<Visitor>();
        }
        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
            ManagerInstance.AddToLogs($"Worker {worker.Name} has entered the zoo and was assigned to {worker.Animal.Name}.");
        }
        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            ManagerInstance.AddToLogs($"{animal.Name} has been added to the zoo.");        }
        public void AddVisitor(Visitor visitor)
        {
            VisitorCount++;
            Visitors.Add(visitor);
            ManagerInstance.AddToLogs($"A new visitor has entered! Current num of visitors: {VisitorCount}");
        }
        public void ExecuteWork()
        {
            foreach (Animal animal in Animals)
            {
                foreach (Worker worker in animal.AssignedWorkers)
                {
                    worker.Work();
                }
            }
        }
        private void SimulateVisitorsEntrance(int numOfVisitors)
        {
            for (int i = 0; i < numOfVisitors; i++)
            {
                Visitor NewVisitor = new Visitor();
                NewVisitor.PreferredLocation = (Location)new Random().Next(0, 4);
                AddVisitor(NewVisitor);
            }
        }
        private void EnqueueVisitors()
        {
            foreach (Visitor v in Visitors)
            {
                VisitorsQueue.Enqueue(v);
            }
            Visitors.Clear();
        }
        private void DistributeVisitors(Tour t)
        {
            int i = 0;
            if (VisitorsQueue.Count < 5)
            {
                while (VisitorsQueue.Count != 0)
                {
                    Visitor v = VisitorsQueue.Dequeue();
                    if (v.PreferredLocation == t.TourLocation)
                    {
                        t.AddParticipants(v);
                        i++;
                    }
                }
            }
            else
            {
                while (VisitorsQueue.Count > 0 && i != 5)
                {
                    Visitor v = VisitorsQueue.Dequeue();
                    if (v.PreferredLocation == t.TourLocation)
                    {
                        t.AddParticipants(v);
                        i++;
                    }
                }
            }
        }
        public void PrintAllAnimals()
        {
            Console.WriteLine("all animals on list:");
            int i = 0;
            foreach (var a in Animals)
            {
                Console.WriteLine($"{i}: {a.Name}");
                i++;
            }
        }
        public bool CheckAnimalDistribution()
        {
            bool landComplete = Animals.Where(a => a.Location == Location.Ground).GroupBy(a => a.GetType().Name).All(g => g.Count() >= 3);
            bool seaComplete = Animals.Where(a => a.Location == Location.Sea).GroupBy(a => a.GetType().Name).All(g => g.Count() >= 3);
            bool airComplete = Animals.Where(a => a.Location == Location.Air).GroupBy(a => a.GetType().Name).All(g => g.Count() >= 3);
            bool mixedComplete = Animals.Where(a => a.Location == Location.Mixed).GroupBy(a => a.GetType().Name).All(g => g.Count() >= 3);

            if (landComplete && seaComplete && airComplete && mixedComplete)
            {
                Console.WriteLine("Animal distribution is complete!");
                return true;
            }
            else
            {
                Console.WriteLine("Animal distribution is incomplete. The following areas need more animals:");

                if (!landComplete)
                {
                    Console.WriteLine("Land:");
                    foreach (var group in Animals.Where(a => a.Location == Location.Ground).GroupBy(a => a.GetType().Name))
                    {
                        Console.WriteLine($"- {group.Key}: {group.Count()}");
                    }
                }

                if (!seaComplete)
                {
                    Console.WriteLine("Sea:");
                    foreach (var group in Animals.Where(a => a.Location == Location.Sea).GroupBy(a => a.GetType().Name))
                    {
                        Console.WriteLine($"- {group.Key}: {group.Count()}");
                    }
                }

                if (!airComplete)
                {
                    Console.WriteLine("Air:");
                    foreach (var group in Animals.Where(a => a.Location == Location.Air).GroupBy(a => a.GetType().Name))
                    {
                        Console.WriteLine($"- {group.Key}: {group.Count()}");
                    }
                }

                if (!mixedComplete)
                {
                    Console.WriteLine("Mixed:");
                    foreach (var group in Animals.Where(a => a.Location == Location.Mixed).GroupBy(a => a.GetType().Name))
                    {
                        Console.WriteLine($"- {group.Key}: {group.Count()}");
                    }
                }

                return false;
            }
        }
        private Dictionary<int, List<Tuple<Worker, Location, string>>> CreateWorkerSchedule()
        {
            const int totalTime = 120;
            Location[] areas = (Location[])Enum.GetValues(typeof(Location));
            Random rand = new Random();
            Dictionary<int, List<Tuple<Worker, Location, string>>> schedule = new Dictionary<int, List<Tuple<Worker, Location, string>>>();
            foreach (Worker worker in Workers)
            {
                List<int> times = new List<int>();
                foreach (Location area in areas)
                {
                    int time = rand.Next(totalTime);
                    while (times.Contains(time) && !CheckIfWorkerFree(worker, times, time))
                        time = rand.Next(totalTime);
                    times.Add(time); // start working
                    if (!schedule.ContainsKey(time))
                        schedule[time] = new List<Tuple<Worker, Location, string>>();
                    if (!schedule.ContainsKey(time + worker.WorkTime))
                        schedule[time + worker.WorkTime] = new List<Tuple<Worker, Location, string>>();
                    schedule[time].Add(Tuple.Create(worker, area, "Start"));
                    schedule[time + worker.WorkTime].Add(Tuple.Create(worker, area, "End"));
                }
            }
            return schedule;
        }
        private Dictionary<int, List<Tuple<Tour, Location, string>>> CreateTourSchedule()
        {
            const int totalTime = 120;
            Location[] tourLocations = (Location[])Enum.GetValues(typeof(Location));
            Random rand = new Random();
            Dictionary<int, List<Tuple<Tour, Location, string>>> schedule = new Dictionary<int, List<Tuple<Tour, Location, string>>>();
            Queue<Tour> tourQueue = new Queue<Tour>(ScheduledTours); //storing on backup
            while (tourQueue.Count > 0)
            {
                Tour tour = tourQueue.Dequeue();
                List<int> times = new List<int>();
                foreach (Location tourLocation in tourLocations)
                {
                    int time = rand.Next(totalTime);
                    times.Add(time); // start tour
                    if (!schedule.ContainsKey(time))
                        schedule[time] = new List<Tuple<Tour, Location, string>>();
                    if (!schedule.ContainsKey(time + tour.TourLength))
                        schedule[time + tour.TourLength] = new List<Tuple<Tour, Location, string>>();
                    schedule[time].Add(Tuple.Create(tour, tourLocation, "Start"));
                    schedule[time + tour.TourLength].Add(Tuple.Create(tour, tourLocation, "End"));
                }
            }
            return schedule;
        }
        private void GenerateTours()
        {
            int numOfTours = new Random().Next(10, 20);
            Random rand = new Random();
            for (int i = 0; i < numOfTours; i++)
            {
                Location randomLocation = (Location)new Random().Next(0, Enum.GetNames(typeof(Location)).Length);
                Tour t = new Tour(this, randomLocation);
                ScheduledTours.Enqueue(t);
            }
        }
        private bool CheckIfWorkerFree(Worker worker, List<int> times, int time)
        {
            for (int i = 0; i < times.Count; i++)
            {
                if (times[i] > time - worker.WorkTime ||
                    times[i] < time + worker.WorkTime)
                    return false;
            }
            return true;
        }
        public void SimulateTourDay()
        {
            SimulateVisitorsEntrance(new Random().Next(30, 51));
            EnqueueVisitors();
            GenerateTours();
            int TourID = 1;
            StartWorking = new WorkerDelegate(Working); //start checking for workers
            Dictionary<int, List<Tuple<Worker, Location, string>>> WorkSchedule = CreateWorkerSchedule();
            Dictionary<int, List<Tuple<Tour, Location, string>>> TourSchedule = CreateTourSchedule();
            const int DayLength = 120;
            Console.WriteLine("Tour day started");
            ManagerInstance.AddToLogs($"Tour day started");
            for (int i = 0; i < DayLength; i++)
            {
                if (WorkSchedule.ContainsKey(i))
                {
                    List<Tuple<Worker, Location, string>> workers = WorkSchedule[i];
                    workers.ForEach(t => StartWorking?.Invoke(t.Item1, t.Item2, t.Item3));
                }
                if (TourSchedule.ContainsKey(i))
                {
                    List<Tuple<Tour, Location, string>> tours = TourSchedule[i];
                    foreach (Tuple<Tour, Location, string> tour in tours)
                    {
                        DistributeVisitors(tour.Item1);
                        int DelaySum = 0;
                        while (DelaysQueue.Count != 0)
                        {
                            int DelayTimeout = DelaysQueue.Dequeue();
                            DelaySum += DelayTimeout;
                        }
                        if (tour.Item1.TourParticipants.Count > 3) //between 3 and 5 are required to start tour
                        {
                            Console.WriteLine("Tour number {0} started", TourID);
                            ManagerInstance.AddToLogs($"Tour number {TourID} started at {tour.Item1.TourLocation}");
                            tour.Item1.SimulateTour();
                            int PeopleTickets = tour.Item1.TourParticipants.Count;
                            switch (block)
                            {
                                case ProfessionBlock.None:
                                    Profit += 50 * PeopleTickets;
                                    break;
                                case ProfessionBlock.DoctorBlock:
                                    Profit += 20 * PeopleTickets;
                                    break;
                                case ProfessionBlock.JanitorBlock:
                                    Profit += 30 * PeopleTickets;
                                    break;
                                case ProfessionBlock.FeederBlock:
                                    Profit += 100 * PeopleTickets;
                                    break;
                            }
                            TourID++;
                        }
                        if (tour.Item1.IsFinished)
                        {
                            if (ScheduledTours.Count != 0)
                            {
                                ScheduledTours.Dequeue(); //current tour is not relevant anymore so we can remove it
                                ManagerInstance.AddToLogs($"Tour {TourID} ended at {tour.Item1.TourLocation}");
                                Tour nextTour = GetTourMatch(tour.Item1);
                            }
                            else break;
                        }
                        if (DelaySum > 0)
                        {
                            Console.WriteLine("There will be a delay of {0} seconds", DelaySum);
                            ManagerInstance.AddToLogs($"Delay for {DelaySum} seconds");
                            Thread.Sleep(DelaySum * 500);
                        }
                    }
                }
                Thread.Sleep(500);
            }
            ManagerInstance.AddToLogs($"Tour day finished");
            ManagerInstance.AddToLogs($"total profit made: {Profit}");
            Console.WriteLine("all tours ended!");
            Console.WriteLine("total profit made: {0}", Profit);
        }
        public void Working(Worker w, Location loc, string status)
        {
            int delay;
            if(status.ToLower() == "start")
            {
                if (w is Doctor || w is Feeder) //delay handler
                {
                    delay = w.WorkTime;
                    DelaysQueue.Enqueue(delay); //adds delay
                }
                switch(w)
                {
                    case Doctor:
                        block = ProfessionBlock.DoctorBlock;
                        break;
                    case Feeder:
                        block = ProfessionBlock.FeederBlock; 
                        break;
                    case Janitor:
                        block = ProfessionBlock.JanitorBlock; 
                        break;
                }
            } else
            {
                block = ProfessionBlock.None;
            }
            string EventString = $"{w.Name}, {loc}, {status}";
            Console.WriteLine(EventString);
            ManagerInstance.AddToLogs(EventString);
        }
        private Tour GetTourMatch(Tour tour)
        {
            foreach (Tour newTour in ScheduledTours)
            {
                switch (tour.TourLocation)
                {
                    case (Location.Air):
                        if (newTour.TourLocation == Location.Air)
                            return newTour;
                        break;
                    case (Location.Ground):
                        if (newTour.TourLocation == Location.Ground ||
                            newTour.TourLocation == Location.Mixed)
                            return newTour;
                        break;
                    case (Location.Sea):
                        if (newTour.TourLocation == Location.Sea ||
                            newTour.TourLocation == Location.Air)
                            return newTour;
                        break;
                    case (Location.Mixed):
                        if (newTour.TourLocation == Location.Sea ||
                            newTour.TourLocation == Location.Mixed ||
                            newTour.TourLocation == Location.Ground)
                            return newTour;
                        break;
                }
            }
            return null;
        }
        public void CreateLogs()
        {
            ManagerInstance.WriteZooLogs();
        }
    }

}

