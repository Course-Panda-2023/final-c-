using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals;
using CSharp_Zoo.ZooWorkers;

namespace CSharp_Zoo.Zoo
{
    public class Zoo
    {
        private List<Animal> _animals;
        private List<ZooWorker> _workers;
        private Director _director;
        private List<Visitors> zooVisitorList = new List<Visitors>();
        
        public List<Animal> Animals { get; set; }
        public List<ZooWorker> Workers { get; set; }
        public Director Director { get; set; }

        public void AddVisitors(in int visitorsNum)
        {
            for (int i = 0; i < visitorsNum; i++)
            {
                zooVisitorList.Add(new Visitors());
            }
        }

        /*public void AssignRandomAnimalToWorkers()
        {
            foreach (var worker in _workers)
            {
                worker.CurrentAnimal = _animals[new Random().Next(0, _animals.Count)];
            }
        }*/
       
        public Zoo(Director director)
        {
            _animals = new List<Animal>();
            _workers = new List<ZooWorker>();
            _director = director;
        }

        public void AddWorker(ZooWorker worker)
        {
            if (!_workers.Contains(worker))
            {
                _workers.Add(worker);
            }
        }
        public void AddAnimal(Animal animal)
        {
            if (!_animals.Contains(animal))
            {
                _animals.Add(animal);
            }
        }
    }
}
