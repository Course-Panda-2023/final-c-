using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooFinalProject
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Sound { get; set; }
        public List<Worker> AssignedWorkers { get; set; }

        protected Animal(string name, string sound, Location location)
        {
            Name = name;
            Sound = sound;
            Location = location;
            AssignedWorkers = new List<Worker>();
        }

        public abstract void PlaySound();

        public void AssignWorker(Worker worker)
        {
            if (worker is Doctor && AssignedWorkers.Exists(w => w is Feeder))
            {
                Console.WriteLine($"Cannot assign {worker.GetType().Name.ToLower()} to {Name} because there is already a feeder assigned.");
            }
            else if (worker is Feeder && AssignedWorkers.Exists(w => w is Doctor))
            {
                Console.WriteLine($"Cannot assign {worker.GetType().Name.ToLower()} to {Name} because there is already a doctor assigned.");
            }
            else if (AssignedWorkers.Exists(w => w.GetType() == worker.GetType()))
            {
                Console.WriteLine($"Cannot assign {worker.GetType().Name.ToLower()} to {Name} because another {worker.GetType().Name.ToLower()} is already assigned.");
            }
            else
            {
                AssignedWorkers.Add(worker);
                Console.WriteLine($"{worker.Name} has been assigned to {Name}.");
            }
        }

    }

}
