using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public static class HelperFunctions
    {
        public static List<ZooWorker> GetZooWorkers()
        {
            List<ZooWorker> workers = new List<ZooWorker>();

            workers.Add(new Cleaner("Cleaner 1", Area.Air));
            workers.Add(new Cleaner("Cleaner 2", Area.Land));
            workers.Add(new Cleaner("Clenar 3", Area.Mixed));
            workers.Add(new Cleaner("Clenar 4", Area.Sea));

            workers.Add(new Doctor("Doctor 1", Area.Air));
            workers.Add(new Doctor("Doctor 2", Area.Land));
            workers.Add(new Doctor("Doctor 3", Area.Mixed));
            workers.Add(new Doctor("Doctor 4", Area.Sea));

            workers.Add(new Feed("Feed 1", Area.Air));
            workers.Add(new Feed("Feed 2",Area.Land));
            workers.Add(new Feed("Feed 3", Area.Mixed));
            workers.Add(new Feed("Feed 4", Area.Sea));

            return workers;
        }

        public static List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            animals.Add(new Eagle("Engle 1"));
            animals.Add(new Eagle("Engle 2"));
            animals.Add(new Pelican("Pelican 1"));
            animals.Add(new Pelican("Pelican 2"));
            animals.Add(new Owl("Owl 1"));

            animals.Add(new Elephant("Elephant 1"));
            animals.Add(new Lion("Lion 1"));
            animals.Add(new Zebra("Zebra 1"));

            animals.Add(new Frog("Frog 1"));
            animals.Add(new Hipo("Hipo 1"));
            animals.Add(new Turtle("Turtle 1"));

            animals.Add(new Dolphin("Dolphin 1"));
            animals.Add(new Whale("Whale 1"));
            animals.Add(new Shark("Shark 1"));

            return animals;
        }

        public static List<Tour> GetTours()
        {
            List<Tour> tours = new List<Tour>();

            tours.Add(new Tour(Area.Land));
            tours.Add(new Tour(Area.Air));
            tours.Add(new Tour(Area.Sea));
            tours.Add(new Tour(Area.Mixed));

            tours.Add(new Tour(Area.Land));
            tours.Add(new Tour(Area.Air));

            return tours;
        }


    }
}
