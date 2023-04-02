using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public abstract class Animal
    {
        protected Area _area;
        public Area GetArea { get { return _area; } }
        protected string _animalName;
        public string AnimalName { get { return _animalName; } }
        protected string _sound;
        protected List<ZooWorker> _workers;

        protected Animal()
        {
            _workers = new List<ZooWorker>();
        }
        public void MakeSound()
        {
            Console.WriteLine($"{_sound} {_animalName}");
        }

        public bool AddWorker(WorkWithAnimal zooWorker)
        {
            if (_workers.Count == 0)
            {
                _workers.Add(zooWorker);
                zooWorker.AddAnimalWorkOn(this);
            }
            else
            {
                // Dr and Feed not togther
                if (zooWorker.GetType() == typeof(Doctor) && !IsWorkerWithType(typeof(Feed)))
                    _workers.Add(zooWorker);
                else if (zooWorker.GetType() == typeof(Feed) && !IsWorkerWithType(typeof(Doctor)))
                    _workers.Add(zooWorker);
                else if (zooWorker.GetType() == typeof(Cleaner))
                    _workers.Add(zooWorker);
                else return false;
            }
            return true;
        }

        private bool IsWorkerWithType(Type type)
        {
            foreach (ZooWorker worker in _workers)
                if (worker.GetType() == type)
                    return true;
            return false;
        }
    }
}
