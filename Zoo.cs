using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
    

public class Zoo
{
    public const int secondLength = 100;
    public const int secondsInDay = 120;
    private const int secondsinTour = 10;
    public static List<Animal> animals;
    private List<Cleaner> cleaners;
    private List<Doctor> doctors;
    private List<Feeder> feeders;
    private int visitors;
    private Dictionary<Zone, int> toursPerZone;
    private bool newTourLock;
    private int tourNum;
    private event Manager.Announcement ToAnnounce;
    private int moneyGained;
    public Zoo(List<Animal> animals, List<Cleaner> cleaners, List<Doctor> doctors, List<Feeder> feeders, int visitorCount)
    {
        Zoo.animals = animals;
        this.cleaners = cleaners;
        this.doctors = doctors;
        this.feeders = feeders;
        this.visitors= visitorCount;
        this.toursPerZone = new Dictionary<Zone, int>();
        foreach (Zone zone in Enum.GetValues(typeof(Zone)))
        {
            toursPerZone[zone] = 0;
        }
        this.newTourLock = false;
        tourNum = 0;
        this.ToAnnounce += Manager.Instance.Announce;
        moneyGained = 0;
    }
    public void StartDay()
    {
        if(AnimalsInZone(Zone.Land) < 3 || AnimalsInZone(Zone.Water) < 3 || AnimalsInZone(Zone.Air) < 3 || AnimalsInZone(Zone.Mixed)  < 3)
        {
            throw new Exception("not enough animals");
        }
        foreach (Cleaner cleaner in cleaners)
            ThreadPool.QueueUserWorkItem(cleaner.StartWorkingDay, secondsInDay);
        foreach (Doctor doctor in doctors)
            ThreadPool.QueueUserWorkItem(doctor.StartWorkingDay, secondsInDay);
        foreach (Feeder feeder in feeders)
            ThreadPool.QueueUserWorkItem(feeder.StartWorkingDay, secondsInDay);
        for (int i = 0; i < secondsInDay; i++)
        {
            this.EverySecond(i);
            Thread.Sleep(secondLength);
        }
        this.ToAnnounce?.Invoke($"Day Ended. Money gained: {moneyGained}");
        Console.ReadLine();
    }
    private int AnimalsInZone(Zone zone)
    {
        int count = 0;
        foreach(Animal animal in animals)
        {
            if (animal.LivingZone == zone) { count++; }
        }
        return count;
    }
    private void EverySecond(int time)
    {
        List<Zone> availableZones = AvailableZones();
        if(availableZones.Count > 0 && time < secondsInDay - secondsinTour && visitors > 0)
        {
            this.newTourLock = true;
            Random rnd = new Random();
            ThreadPool.QueueUserWorkItem(Tour, availableZones[rnd.Next(availableZones.Count())]);
        }
        Thread.Sleep(secondLength);
    }
    private void Tour(Object zoneObj)
    {
        int thisTourNum = tourNum++;
        this.visitors -= 5;
        if (visitors < 0) { visitors = 0; }
        Zone zone = (Zone)zoneObj;
        moneyGained += GetPriceForTour(zone);
        this.ToAnnounce?.Invoke($"Began tour {thisTourNum} in {zone}");
        this.toursPerZone[zone] ++;
        this.newTourLock = false;
        Thread.Sleep(secondsinTour * secondLength);
        WaitForAnimalWorker(zone);
        this.toursPerZone[zone]--;
        this.ToAnnounce?.Invoke($"Ended tour {thisTourNum} in {zone}");
    }
    private int GetPriceForTour(Zone zone)
    {
        int price = 50;
        foreach(Worker worker in doctors)
        {
            if(worker.CurZone == zone)
                price = worker.PriceChange; break;
        }
        foreach (Worker worker in feeders)
        {
            if (worker.CurZone == zone)
                price = worker.PriceChange; break;
        }
        foreach (Worker worker in cleaners)
        {
            if (worker.CurZone == zone)
                price = worker.PriceChange; break;
        }
        return price;
    }
    private void WaitForAnimalWorker(Zone zone)
    {
        List<Worker> delayingWorkers = CurrentDelayingWorkers(zone);
        while(delayingWorkers.AsQueryable().Intersect(CurrentDelayingWorkers(zone)).Count()>0);
        {
            Thread.Sleep(secondLength);
        }
    }
    private List<Worker> CurrentDelayingWorkers(Zone zone)
    {
        List<Worker> delayingWorkers = new List<Worker>();
        foreach (Doctor doctor in this.doctors)
        {
            if (doctor.CurZone == zone) { delayingWorkers.Add(doctor); }
        }
        foreach (Cleaner cleaner in this.cleaners)
        {
            if (cleaner.CurZone == zone) { delayingWorkers.Add(cleaner); }
        }
        return delayingWorkers;
    }
    private List<Zone> AvailableZones()
    {
        lock (this.toursPerZone)
        {
            List<Zone> availableZones = new List<Zone>();
            foreach (Zone zone in Enum.GetValues(typeof(Zone)))
            {
                if (toursPerZone[zone] < 2)
                    availableZones.Add(zone);
            }
            if (toursPerZone[Zone.Air] > 0)
                { availableZones.Remove(Zone.Land); availableZones.Remove(Zone.Mixed); }
            if (toursPerZone[Zone.Mixed] > 0)
                availableZones.Remove(Zone.Air);
            if (toursPerZone[Zone.Water] > 0)
                availableZones.Remove(Zone.Land);
            if (toursPerZone[Zone.Land] > 0)
                { availableZones.Remove(Zone.Air); availableZones.Remove(Zone.Water); }
            return availableZones;
        }
    }   
}
