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

        public List<Animal> Animals { get; set; }
        public List<ZooWorker> Workers { get; set; }
        public Director Director { get; set; }

        /*public Zoo(List<Animal> animals, List<ZooWorker> workers, Director director, List<Animal> animals, List<ZooWorker> workers, Director director)
        {
            Animals = animals;
            Workers = workers;
            Director = director;
            Animals = animals;
            Workers = workers;
            Director = director;
        }*/
        public Zoo(Director director)
        {
            _animals = new List<Animal>();
            _workers = new List<ZooWorker>();
            _director = director;
        }

        public void AddAnimal(Animal animal)
        {
            if (!_animals.Contains(animal))
            {
                _animals.Add(animal);
            }
        }
        /*public void StartPatrol()
        {
            // start the patrol thread
            Thread thread = new Thread(new ThreadStart(_staffPatrol.Patrol));
            thread.Start();
        }*/
    }
}
