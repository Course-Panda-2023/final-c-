using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FinalProjectCSharp
{
    public enum Area
    {
        Air,
        Sea,
        Land,
        Mixed
    }
   
    public class Zoo
    {
        private static int TOTAL_DAY = 120; // ms

        private Dictionary<Area, List<Animal>> _animals;
        private Dictionary<Area, List<Visitor>> _visitors;
        private List<ZooWorker> _zooWorkers;
        private List<Tour> _tours;
        private delegate void WorkerDelegate(ZooWorker worker, Area area, String status);
        private event WorkerDelegate DoWork;
        private ZooManager _zooManager;
        public Zoo()
        {
            _animals = new Dictionary<Area, List<Animal>>();
            _animals[Area.Air] = new List<Animal>();
            _animals[Area.Sea] = new List<Animal>();
            _animals[Area.Land] = new List<Animal>();
            _animals[Area.Mixed] = new List<Animal>();

            _visitors = new Dictionary<Area, List<Visitor>>();
            _visitors[Area.Air] = new List<Visitor>();
            _visitors[Area.Sea] = new List<Visitor>();
            _visitors[Area.Land] = new List<Visitor>();
            _visitors[Area.Mixed] = new List<Visitor>();

            _zooWorkers = new List<ZooWorker>();
            _tours = new List<Tour>();

            _zooManager = ZooManager.GetInstance;
        }

        public void AddAnimal(Animal animal)
        {
            Area area = animal.GetArea;
            bool existTypeAnimal = CheckIfAnimalAlreadyExist(animal.GetType(), area);
            if (!existTypeAnimal && _animals[area].Count < 3)
            {
                _animals[area].Add(animal);
                string output = $"{animal.AnimalName} is added to {area} :)";
                _zooManager.AddToLog(output);
                Console.WriteLine(output);
            }
        }

        private int MenuForShowAnimals(Area area)
        {
            string removeStr = "Choose the number of the animal you want to remove:";
            Console.WriteLine(removeStr);
            PrintAnimalsInArea(area);
            return int.Parse(Console.ReadLine());
        }
        private void PrintAnimalsInArea(Area area)
        {
            List<Animal> animals = _animals[area];
            for (int i = 0; i < animals.Count; i++)
                Console.WriteLine($"{i + 1}. {animals[i].AnimalName}");
        }
        public void RemoveAnimal()
        {
            Console.WriteLine("Removing Animal Menu:");
            Console.WriteLine("Select the area of the animal:");
            Console.WriteLine("1. Air");
            Console.WriteLine("2. Land");
            Console.WriteLine("3. Sea");
            Console.WriteLine("4. Mixed");
            int selectArea = int.Parse(Console.ReadLine());
            int selectAnimalRemove = 0;
            switch (selectArea)
            {
                case 1:
                    selectAnimalRemove = MenuForShowAnimals(Area.Air);
                    if(selectAnimalRemove > 0)
                        _animals[Area.Air].RemoveAt(selectAnimalRemove - 1);
                    break;
                case 2:
                    selectAnimalRemove = MenuForShowAnimals(Area.Land);
                    if (selectAnimalRemove > 0)
                        _animals[Area.Land].RemoveAt(selectAnimalRemove - 1);
                    break;
                case 3:
                    selectAnimalRemove = MenuForShowAnimals(Area.Sea);
                    if (selectAnimalRemove > 0)
                        _animals[Area.Sea].RemoveAt(selectAnimalRemove - 1);
                    break;
                case 4:
                    selectAnimalRemove = MenuForShowAnimals(Area.Mixed);
                    if (selectAnimalRemove > 0)
                        _animals[Area.Mixed].RemoveAt(selectAnimalRemove - 1);
                    break;
            
            }


        }

        public void ShowAnimals()
        {
            Console.WriteLine("Show All Animals in Zoo ☺");
            Area[] areas = (Area[])Enum.GetValues(typeof(Area));
            foreach(Area area in areas)
                PrintAnimalsInArea(area);
        }

        public bool AddWorker(ZooWorker worker)
        {
            if (!_zooWorkers.Contains(worker))
            {
                string output = $"{worker.Name} is added to {worker.Area} :)";
                _zooManager.AddToLog(output);
                _zooWorkers.Add(worker);
                return true;
            }
            return false;
        }

        public void RemoveWorker(ZooWorker worker)
        {
            _zooManager.AddToLog($"{worker.Name} is removed.");
            _zooWorkers.Remove(worker);
        }
        
        public void AddTour(Tour tour)
        {
            if (!_tours.Contains(tour))
            {
                _tours.Add(tour);
                _zooManager.AddToLog($"Adding Tour");
            }
        }
        public void ToursDay()
        {
            DoWork += new WorkerDelegate(Working);
            // Match between Worker and Area
            SortedDictionary< int, List<Tuple<ZooWorker, Area, string>>> schedule = CreateSchedule();

            // show the schedule
            //PrintSchedule(schedule);

            int tourTime = 10000; // 10s in ms
            Console.WriteLine("**** Start Tour Day ****");
            for (int i = 0; i < TOTAL_DAY; i++)
            {
                Console.WriteLine($"{i} sec in tour");
                // new visitors come
                CreateVisitors();
                List<Type> zooWorkersTypes = new List<Type>();
                // delay of working
                int delay = 0;
                // Checks if there are workers which start/end work
                if (schedule.ContainsKey(i))
                {
                    List<Tuple<ZooWorker, Area, string>> workers = schedule[i];
                    workers.ForEach(t => DoWork?.Invoke(t.Item1, t.Item2, t.Item3));
                    delay = GetTheAmountTimeDelay(
                        workers.Where(t => (t.Item1.GetType() == typeof(Doctor)
                        || t.Item1.GetType() == typeof(Cleaner)) && t.Item3.Equals("Start")).ToList());


                }
                if (delay > 0)
                {
                    i += (delay-1);
                    Thread.Sleep(delay * 1000);
                    Console.WriteLine($"Delay of {delay} sec");
                }
                else
                {
                    Tour firstTour = null;
                    if (_tours.Count > 0)
                    {
                        firstTour = _tours[0];
                        _tours.Remove(firstTour);
                        Tour secondTour = GetTourMatch(firstTour);
                        AddVisitorsToTour(firstTour);
                        firstTour.startTour(_animals[firstTour.AreaTour]);
                        if (secondTour != null)
                        {
                            AddVisitorsToTour(secondTour);
                            secondTour.startTour(_animals[firstTour.AreaTour]);
                            _tours.Remove(secondTour);
                        }
                        // waiting 10 sec
                        Thread.Sleep(tourTime);
                        i += 9;
                    }
                    
                } 
            }
            Console.WriteLine("**** Tours Ended ****");
        }

        // PRIVATE FUNCTIONS 

        private void PrintSchedule(SortedDictionary<int, List<Tuple<ZooWorker, Area, string>>> schedule)
        {
            foreach(KeyValuePair<int, List<Tuple<ZooWorker, Area, string>>> item in schedule)
            {
                Console.WriteLine($"Time: {item.Key} sec");
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Tuple<ZooWorker, Area, string> tuple = item.Value[i];
                    Console.WriteLine($"Worker: {tuple.Item1.Name}, Area: {tuple.Item2}, Status: {tuple.Item3}");
                }
            }
        }
        private void AddVisitorsToTour(Tour tour)
        {
            Area area = tour.AreaTour;
            while (_visitors[area].Count > 0 
                && tour.AddVisitor(_visitors[area][0]))
                _visitors[area].RemoveAt(0);
        }

        private void Working(ZooWorker worker, Area area, String status)
        {
            if (worker.GetType() == typeof(WorkWithAnimal))
            {
                if (status.Equals("Start"))
                {
                    MatchAnimalAndWorker(area, ((WorkWithAnimal)worker));
                    _zooManager.AddToLog($"{worker.Name} start working...");
                }
                else // finish
                {
                    string str = ((WorkWithAnimal)worker).FinishedWorkWithAnimal();
                    _zooManager.AddToLog(str);
                }
            }
            else
            {
                string output = $"{worker.Name} {status.ToLower()} cleaning in {area}";
                _zooManager.AddToLog(output);
                Console.WriteLine(output);
            }
        }

        private Animal MatchAnimalAndWorker(Area area, WorkWithAnimal worker)
        {
            foreach (Animal animal in _animals[area])
            {
                if (animal.AddWorker(worker))
                    return animal;
            }
            return null; // there is not find animals to care of in this area
        }

        private bool CheckIfAnimalAlreadyExist(Type animalType, Area area)
        {
            foreach(Animal animal in _animals[area])
            {
                if(animal.GetType() == animalType)
                    return true;
            }
            return false;
        }
        
        private Tour GetTourMatch(Tour tour)
        {
            foreach(Tour newTour in _tours)
            {
                switch (tour.AreaTour)
                {
                    case (Area.Air):
                        if (newTour.AreaTour == Area.Air)
                            return newTour;
                        break;
                    case (Area.Land):
                        if (newTour.AreaTour == Area.Land ||
                            newTour.AreaTour == Area.Mixed)
                            return newTour;
                        break;
                    case (Area.Sea):
                        if (newTour.AreaTour == Area.Sea ||
                            newTour.AreaTour == Area.Air)
                            return newTour;
                        break;
                    case (Area.Mixed):
                        if (newTour.AreaTour == Area.Sea ||
                            newTour.AreaTour == Area.Mixed ||
                            newTour.AreaTour == Area.Land)
                            return newTour;
                        break;
                }
            }
            return null;
        }

        private SortedDictionary<int, List<Tuple<ZooWorker, Area, string>>> CreateSchedule()
        {
            int totalTime = 120;
            Area[] areas = (Area[])Enum.GetValues(typeof(Area));
            Random rand = new Random();
            SortedDictionary<int, List<Tuple<ZooWorker, Area, string>>> schedule = new SortedDictionary<int, List<Tuple<ZooWorker, Area, string>>>();
            foreach(ZooWorker worker in _zooWorkers)
            {
                // list which contains the start time of each area, specific to worker
                List<int> times = new List<int>();
                foreach(Area area in areas)
                {
                    int time = rand.Next(totalTime);
                    while (times.Contains(time) && !CheckIfWorkerFree(worker, times, time))
                        time = rand.Next(totalTime);
                    times.Add(time); // start working
                    if (!schedule.ContainsKey(time))
                        schedule[time] = new List<Tuple<ZooWorker, Area, string>>();
                    if (!schedule.ContainsKey(time+worker.WorkTime))
                       schedule[time+worker.WorkTime] = new List<Tuple<ZooWorker, Area, string>>();

                    schedule[time].Add(Tuple.Create(worker, area, "Start"));
                    schedule[time+worker.WorkTime].Add(Tuple.Create(worker, area,"End"));
                }
            }
            return schedule;
        }

        private bool CheckIfWorkerFree(ZooWorker worker, List<int> times, int time)
        {

            for (int i = 0; i < times.Count; i++)
            {
                if (times[i] > time - worker.WorkTime && 
                    times[i] < time + worker.WorkTime)
                    return false;
            }
            return true;
        }

        private int GetTheAmountTimeDelay(List<Tuple<ZooWorker, Area, string>> workers)
        {
            int delay = 0;
            foreach(Tuple<ZooWorker,Area,String> tuple in workers)
            {
                if (tuple.Item1.GetType() == typeof(Doctor))
                    return 5;
                else if (tuple.Item1.GetType() == typeof(Cleaner))
                    delay = 2;
            }
            return delay;
        }

        private void CreateVisitors()
        {
            Random rand = new Random();
            int MAX_VISITORS = 10;
            int randomNumber = rand.Next(0, MAX_VISITORS);
            Area[] areas = (Area[])Enum.GetValues(typeof(Area));
            for (int i = 0; i < randomNumber; i++)
            {
                Area selectedArea = areas[rand.Next(areas.Length)];
                _visitors[selectedArea].Add(new Visitor(selectedArea));
            }
        }
        public void AddToLog(string str)
        {
            _zooManager.AddToLog(str);
        }
        public void WriteToLog()
        {
            _zooManager.InitiateLog();
        }
    }
}
