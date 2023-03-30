using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZooFinalProject
{
    public class Tour
    {
        public static int TourId = 1;
        public Zoo Zoo { get; set; }
        public List<Visitor> TourParticipants { get; set; }
        public Location TourLocation { get; set; }
        public int TourLength { get; set; }
        public bool IsFinished { get; set; }
        public Tour(Zoo z, List<Visitor> tourParticipants, Location tourLocation)
        {
            TourId++;
            this.Zoo = z;
            TourParticipants = tourParticipants;
            TourLocation = tourLocation;
            TourLength = 10;
            IsFinished = false;
        }

        public Tour(Zoo zoo, Location tourLocation)
        { //doesnt add tour id to save location
            Zoo = zoo;
            TourLocation = tourLocation;
            TourParticipants = new List<Visitor>();
            TourLength = 10;
            IsFinished = false;

        }

        public void AddParticipants(Visitor v)
        {
            TourParticipants.Add(v);
        }
        public void SimulateTour()
        {
            Thread TourThread = new Thread(() =>
            {
                Animal[] AnimalsAtTourLocation = (from animal in Zoo.Animals
                                                            where animal.Location == TourLocation
                                                            select animal).ToArray();
                Console.WriteLine($"welcome to the zoo at location {TourLocation.ToString()}. check out all the animals:");
                foreach (var Animal in AnimalsAtTourLocation)
                {
                    Console.WriteLine($"behold, the {Animal.Name}!");
                    Animal.PlaySound();
                }
                Thread.Sleep(TourLength * 1000);
                Console.WriteLine($"thats it for the tour id {TourId}, thanks for coming!");
                TourId++;
                IsFinished = true; //after the thread is finished, the tour is marked as finished
            });
            TourThread.Start();
        }
    }
}
