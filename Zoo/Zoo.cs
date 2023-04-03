using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;
using Zoo.Animals.AirAnimals;
using Zoo.Animals.LandAnimals;
using Zoo.Animals.MixedAnimals;
using Zoo.Animals.SeaAnimals;
using Zoo.Workers;

namespace Zoo
{
    public class Zoo
    {
        public static object LandTour;
        public static object AirTour;
        public static object SeaTour;
        public static object MixTour;

        public List<Animal> Animals;
        public List<Worker> Workers;
        public List<Person> Visitors;

        //private int CurrentTime = 0; 
        public const int SECONDS_IN_DAY = 120;
        public delegate void FieldChangedEventHandler();
        public event FieldChangedEventHandler CurrentTimeChanged;

        public int CurrentTime //seconds
        {
            get { return CurrentTime; }
            set
            {
                if (CurrentTime != value)
                {
                    CurrentTime = value;
                    OnCurrentTimeChange();
                }
            }
        }
        
        protected virtual void OnCurrentTimeChange()
        {
            CurrentTimeChanged?.Invoke();
        }

        //find the worker that should work at this time and make him work
        public void WorkWokers()
        {
            foreach (Worker worker in this.Workers)
            {
                if (worker.IsWorkingAtTime(CurrentTime)) { 
                    //TODO: we need to add here to pause a tour in the current zone that the worker is working.
                    //only for doctor and cleaner
                    worker.DoWork();
                    //resume
                }
            }
        }

        public void ZooInit() {
            CurrentTimeChanged += new FieldChangedEventHandler(WorkWokers);
            Animal animalAir1 = new Eagle("Moshe");
            Animal animalAir2 = new Hawk("Yoram");
            Animal animalAir3 = new Owl("Yakov");
            Animal animalLand1 = new Elephant("Raanan");
            Animal animalLand2 = new Jiraff("Yoav");
            Animal animalLand3 = new Kangeroo("David");
            Animal animalMix1 = new Alligator("Brit");
            Animal animalMix2 = new Duck("Avraham");
            Animal animalMix3 = new Frog("Gaon");
            Animal animalSea1 = new Dolphin("Arik");
            Animal animalSea2 = new GoldFish("Kora");
            Animal animalSea3 = new Shark("Mike");

            this.Animals = new List<Animal> { animalAir1, animalAir2, animalAir3,
                animalLand1, animalLand2, animalLand3, 
                animalMix1, animalMix2, animalMix3, 
                animalSea1, animalSea2, animalSea3};
            
            Worker worker1 = new Cleaner("Eyal", Area.Land);
            Worker worker2 = new Doctor("Avram", animalMix3);
            Worker worker3 = new Feeder("Shay", animalLand1);
            this.Workers = new List<Worker>{worker1, worker2, worker3 };

            Person p1= new Person("Emil");
            Person p2= new Person("Yossi");
            Person p3= new Person("Moshe");
            Person p4= new Person("Kokav");
            Person p5= new Person("Hertzi");
            Person p6= new Person("Amnon");
            Person p7= new Person("Yoav");
            Person p8= new Person("Shadi");
            Person p9= new Person("Mohammed");
            Person p10= new Person("Yoram");
            this.Visitors = new List<Person> {p1,p2,p3,p4,p5,p6,p7,p8,p9,p10 };
        }    
       
       public void StartTour(string location, object objToLock, List<Person> visitors)
       {
           lock (objToLock)
           {

                Console.WriteLine($"Touring in the {location}!...");
                Thread.Sleep(10000);
                Console.WriteLine($"{location} tour is finished...");
            }
       }

        public void InitAllWorkers()
        {
            foreach (Worker worker in this.Workers)
            {
                worker.InitWorkingTimes();
            }
        }

        private void TickClock()
        {
            this.CurrentTime++;
        }

        public object RandomTourArea()
        {
            Random rnd = new Random();
            List<object> areasObjects = new List<object> { LandTour, AirTour, MixTour, SeaTour};
            return areasObjects[rnd.Next( areasObjects.Count - 1)];
        }

        public List<Person> AssignePeopleToTour()
        {
            List<Person> currentTour = new List<Person> ();

            for (int visitorIndex = 0; visitorIndex < 5 || Visitors.Count > 0; visitorIndex++)
            {
                currentTour.Add(this.Visitors[0]);
                this.Visitors.RemoveAt(0);
            }

            return currentTour;
        }

        
        public void RunDayInZoo()
        {
            InitAllWorkers();
            while (this.CurrentTime != SECONDS_IN_DAY)
            {
                TickClock();
                Thread.Sleep(1000);
                object tourPlace = this.RandomTourArea();
                List<Person> currentTour = AssignePeopleToTour();
                Thread runningTour = new Thread(()=> StartTour((string)tourPlace, tourPlace, currentTour));\
                runningTour.Start();
            }

            this.CurrentTime = 0;
        }
    }
}
