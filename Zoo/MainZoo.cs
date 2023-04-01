using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public delegate void notify(int time);
    public class MainZoo
    {
        const int workDay = 120;
        const int tourTime = 10;

        static ZooManager Manager = ZooManager.Instance;
        public static int time = 0;

        private List<Animal> animals;
        private List<Worker> workers;
        private Dictionary<int, List<Worker>> workersDictStart;
        private Dictionary<int, List<Worker>> workersDictFinish;
        private List<Tour> tours;
        private int tourId;
        private int zooIncome;


        public event notify zooEvents;

        public MainZoo(List<Animal> animals, List<Worker> workers)
        {
            if (CheckZoo(animals))
            {
                this.animals = animals;
                tourId = 1;
                this.workers = workers;
                workersDictStart = new Dictionary<int, List<Worker>>();
                workersDictFinish = new Dictionary<int, List<Worker>>();
                tours = new List<Tour>();
                AddWorkersToDicts();
                zooEvents += new notify(PrintStartAndFinish);
                zooEvents += new notify(AddAndRemoveTours);
                zooIncome = 0;
                Manager.LogEvents("Zoo created.");
            }
            else
                Manager.LogEvents("Can't create Zoo.");
        }

        public bool CheckZoo(List<Animal> animalArr)
        {
            int landCounter = 0;
            int seaCounter = 0;
            int skyCounter = 0;
            int mixCounter = 0;
            List<Animal> tempAnimals = new List<Animal>();

            foreach (Animal animal in animalArr)
            {
                for(int i = 0; i < tempAnimals.Count; i++)
                {
                    if(animal.GetType().ToString() == animalArr[i].GetType().ToString())
                    {
                        Manager.LogEvents("Found two the same.");
                        return false;
                    }
                }
                switch (animal)
                {
                    case LandAnimals:
                        landCounter++;
                        break;
                    case SeaAnimals:
                        seaCounter++;
                        break;
                    case SkyAnimals:
                        skyCounter++;
                        break;
                    case MixedAnimal:
                        mixCounter++;
                        break;
                }
                tempAnimals.Add(animal);
            }
            return landCounter >= 3 && seaCounter >= 3 && skyCounter >= 3 && mixCounter >= 3;
        }

        public void AddWorkersToDicts()
        {
            foreach(Worker w in workers)
            {
                foreach(int time in w.WorkingTimes)
                {
                    AddToDictsHelper(ref workersDictStart, w, time);
                    AddToDictsHelper(ref workersDictFinish, w, time + w.WorkingInterval);
                }
            }
        }

        public void AddToDictsHelper(ref Dictionary<int, List<Worker>> dict, Worker w, int time)
        {
            try
            {
                dict[time].Add(w);
            }
            catch (Exception e)
            {
                List<Worker> temp = new List<Worker>();
                temp.Add(w);
                dict.Add(time, temp);
            }
        }

        public void PrintStartAndFinish(int time)
        {
            if (workersDictFinish.ContainsKey(time))
            {
                foreach (Worker w in workersDictFinish[time])
                {
                    Manager.LogEvents($"Worker {w.GetType().Name + (workers.IndexOf(w) + 1)} finished working at {w.CurrentArea}");
                    if (w is NonCleaners)
                    {
                        NonCleaners worker = (NonCleaners)w;
                        int animalIndex = animals.IndexOf(worker.CurrentAnimal);
                        if (animalIndex != -1)
                            animals[animalIndex].IsTreated = false;
                    }
                    w.CurrentArea = (Areas)w.GetNextArea();
                }
                foreach (Tour t in tours)
                {
                    if (IsAreaFree(t.Area) && t.IsPaused)
                    {
                        t.ResumeTour(time);
                        //Thread.Sleep(50);
                    }
                }
            }
            if (workersDictStart.ContainsKey(time))
                foreach (Worker w in workersDictStart[time])
                {
                    Manager.LogEvents($"Worker {w.GetType().Name + (workers.IndexOf(w) + 1)} started working at {w.CurrentArea}");
                    if (w is NonCleaners)
                    {
                        NonCleaners worker = (NonCleaners)w;
                        worker.CurrentAnimal = GetNextAnimal(w.CurrentArea);
                        if (worker.CurrentAnimal != null)
                            Manager.LogEvents($" on animal {worker.CurrentAnimal.GetType().Name} - {worker.CurrentAnimal.Name}");
                    }
                    foreach (Tour t in tours)
                    {
                        if (t.Area == w.CurrentArea && !t.IsPaused && !(w is Feader))
                        {
                            t.PauseTour(time, w);
                            //Thread.Sleep(50);
                        }
                    }
                }
        }

        public bool IsAreaFree(Areas area)
        {
            foreach(Worker w in workers)
            {
                if(w.CurrentArea == area)
                {
                    return false;
                }
            }
            return true;
        }
        public Animal GetNextAnimal(Areas area)
        {
            Random r = new Random();
            foreach (int i in Enumerable.Range(0, animals.Count).OrderBy(x => r.Next()))
            {
                if (animals[i].Areas == area && !animals[i].IsTreated)
                {
                    animals[i].IsTreated = true;
                    return animals[i];
                }
            }
            return null;
        }

        public void AddAndRemoveTours(int time)
        {
            const int numOfAreas = 4;
            const int maxTimeToStartTour = workDay - tourTime;
            const int numOfVisitors = 5;

            Random r = new Random();
            int visitorsInTour = r.Next(numOfVisitors - 2, numOfVisitors + 2);
            List<Visitor> visitors = new List<Visitor>();
            for(int i = 0; i < visitorsInTour; i++)
            {
                visitors.Add(new Visitor());
            }
            List<Tour> toursToRemove = new List<Tour>();
            int tourAreaCounter = 0;
            bool AddTour = true;
            Random rnd = new Random();
            Areas area = (Areas)rnd.Next(0, numOfAreas);
            foreach(Tour t in tours)
            {
                if(t.Area == area)
                    tourAreaCounter++;
                if(!CheckTour(t, area))
                {
                    AddTour = false;
                }
                if (t.IsDone)
                {
                    toursToRemove.Add(t);
                }
            }
            if (AddTour && tourAreaCounter < 2 && time <= maxTimeToStartTour)
            {
                Tour tour = new Tour(area, time, tourId, visitors);
                tourId++;
                tours.Add(tour);
                zooIncome += visitorsInTour * GetTicketCost(area);
            }
            foreach(Tour t in toursToRemove)
            {
                if(tours.Contains(t))
                    tours.Remove(t);
            }
            toursToRemove.Clear();
            AddTour = true;
        }

        public bool CheckTour(Tour t, Areas area)
        {
            if ((area.GetHashCode() == 0 && (t.Area.GetHashCode() == 1 || t.Area.GetHashCode() == 2)) ||
                (area.GetHashCode() == 2 && (t.Area.GetHashCode() == 3 || t.Area.GetHashCode() == 0)) ||
                (area.GetHashCode() == 1 && t.Area.GetHashCode() == 0) ||
                (area.GetHashCode() == 3 && t.Area.GetHashCode() == 2))
            {
                return false;
            }
            return true;
        }

        public int GetTicketCost(Areas area)
        {
            const int regularTicket = 50;

            int ticketCost = 0;
            foreach(Worker worker in workers)
            {
                if(worker.CurrentArea == area)
                {
                    ticketCost = Math.Max(worker.TicketCost, ticketCost);
                }
            }
            return ticketCost == 0 ? regularTicket : ticketCost;
        }

        public void Run(bool IsBonus)
        {
            for (int i = 0; i < workDay; i++)
            {
                time = i + 1;
                Manager.LogEvents($"time: {i + 1}");
                zooEvents.Invoke(i + 1);
                Thread.Sleep(100);
                Manager.LogEvents("");
            }
            foreach (Tour tour in tours)
                tour.T.Join();
            if (IsBonus)
            {
                Manager.LogEvents($"Zoo income today: {zooIncome}");
            }
        }
    }
}
