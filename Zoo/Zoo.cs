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
        public List<ZooWorker> _workers;
        private Director _director;
        private List<Visitors> _zooVisitorList;

        public Zoo()
        {
            _animals = new List<Animal>();
            _workers = new List<ZooWorker>();
            _zooVisitorList = new List<Visitors>();
        }

        public List<Animal> Animals { get => _animals; set => _animals = value; }
        public List<ZooWorker> Workers { get => _workers; set => _workers = value; }
        public Director Director { get => _director; set => _director = value; }


        public void AddVisitors(in int visitorsNum)
        {
            for (int i = 0; i < visitorsNum; i++)
            {
                _zooVisitorList.Add(new Visitors());
            }
        }

        public void AddDirector(Director director)
        {
            Director = director;
        }

        public void AddWorker(ZooWorker worker)
        {
            if (worker == null)
            {
                Console.WriteLine("Worker is null");
                return;
            }

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
