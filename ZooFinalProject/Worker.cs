using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooFinalProject
{
    public abstract class Worker
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public Animal Animal { get; set; }
        public int WorkTime { get; set; }
        public Dictionary<Location, int> WorkerArrivalTimes { get; set; }

        public Worker(string name, Location location, Animal animal)
        {
            Name = name;
            Location = location;
            Animal = animal;
        }

        //public void SetRandomArrivalTimes()
        //{
        //    Random rand = new Random();
        //    WorkerArrivalTimes = new Dictionary<Location, int>()
        //    {
        //        {Location.Ground, rand.Next(0, 120) * 1000 },
        //        {Location.Air, rand.Next(0, 120) * 1000 },
        //        {Location.Sea, rand.Next(0, 120) * 1000 },
        //        {Location.Mixed, rand.Next(0, 120) * 1000}
        //    };
        //    // Generate a random arrival time within a 2-minute window for each area
        //    //var rand = new Random();
        //    //WorkerArrivalTimes = new Dictionary<Location, DateTime>()
        //    //{
        //    //    { Location.Ground, DateTime.Today.Add(TimeSpan.FromMinutes(rand.Next(0, 120))) },
        //    //    { Location.Sea, DateTime.Today.Add(TimeSpan.FromMinutes(rand.Next(0, 120))) },
        //    //    { Location.Air, DateTime.Today.Add(TimeSpan.FromMinutes(rand.Next(0, 120))) },
        //    //    { Location.Mixed, DateTime.Today.Add(TimeSpan.FromMinutes(rand.Next(0, 120))) }
        //    //};
        //}
        public abstract void Work();
    }
    public class Feeder : Worker
    {
        public Feeder(string name, Location location, Animal animal) : base(name, location, animal)
        {
            WorkTime = 10;
        }

        public override void Work()
        {
            Thread workThread = new Thread(() =>
            {
                FeederThreadedWork();
            });
            workThread.Start();
        }

        private void FeederThreadedWork()
        {
            if (Location == Animal.Location)
            {
                Console.WriteLine($"{Name}: Currently feeding {Animal.Name}...");
                Thread.Sleep(WorkTime * 1000);
                Console.WriteLine($"{Name}: Done!");
            }
            else
            {
                Console.WriteLine($"{Name} is not in the same location as {Animal.Name}");
            }
        }
    }

    public class Doctor : Worker
    {
        public Doctor(string name, Location location, Animal animal) : base(name, location, animal)
        {
            WorkTime = 5;
        }

        public override void Work()
        {
            Thread workThread = new Thread(() =>
            {
                DoctorThreadedWork();
            });
            workThread.Start();
        }

        private void DoctorThreadedWork()
        {
            if (Location == Animal.Location)
            {
                Console.WriteLine($"{Name}: Currently treating {Animal.Name}...");
                Thread.Sleep(WorkTime * 1000);
                Console.WriteLine($"{Name}: Done!");
            }
            else
            {
                Console.WriteLine($"{Name} is not in the same location as {Animal.Name}");
            }
        }
    }

    public class Janitor : Worker
    {
        public Janitor(string name, Location location, Animal animal) : base(name, location, animal)
        {
            WorkTime = 2;
        }

        public override void Work()
        {
            Thread workThread = new Thread(() =>
            {
                JanitorThreadedWork();
            });
            workThread.Start();
        }

        private void JanitorThreadedWork()
        {
            if (Location == Animal.Location)
            {
                Console.WriteLine($"{Name}: Currently cleaning {Animal.Name}'s area...");
                Thread.Sleep(WorkTime * 1000);
                Console.WriteLine($"{Name}: Done!");
            }
            else
            {
                Console.WriteLine($"{Name} is not in the same location as {Animal.Name}");
            }
        }
    }
}
