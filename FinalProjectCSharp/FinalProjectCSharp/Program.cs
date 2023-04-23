using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProjectCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            List<ZooWorker> workers = HelperFunctions.GetZooWorkers();
            List<Animal> animals = HelperFunctions.GetAnimals();
            List<Tour> tours = HelperFunctions.GetTours();
            // Adding the animals 
            foreach (Animal animal in animals)
                zoo.AddAnimal(animal);

            // Adding the workers
            foreach (ZooWorker worker in workers)
                zoo.AddWorker(worker);

            // Adding the tours
            foreach (Tour tour in tours)
                zoo.AddTour(tour);

            // DAY TOUR

            //zoo.ToursDay();
            zoo.WriteToLog();
        }
    }
}
