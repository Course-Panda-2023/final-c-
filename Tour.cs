using CSharp_Zoo.ZooWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CSharp_Zoo
{
    public class Tour
    {
        public ZoneTypes Zone { get; set; }
        public List<Visitors> Visitors { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class Tours
    {
        private static readonly int[,] TourConstraints = new int[,]
        {
            { 1, 0, 0, 1 },
            { 0, 1, 1, 0 },
            { 0, 1, 1, 1 },
            { 1, 0, 1, 1 }
        };

        private Zoo.Zoo _zoo;
        private List<Tour> _activeTours;
        private List<Visitors> _waitingVisitors;
        private Random _random;
        private Dictionary<ZooWorker, ZoneTypes> _currentWorkerZones;
        private const int _dayLength = 1;
        private const int _maxVisitorsNum = 5;
        private void ScheduleWorkers(TimeSpan day, DateTime startTime)
        {
            // TimeSpan day = TimeSpan.FromMinutes(2);
            // DateTime startTime = DateTime.Now;

            List<ZoneTypes> zonesToVisit = Enum.GetValues(typeof(ZoneTypes)).Cast<ZoneTypes>().ToList(); //to put to the worker's constructor, such that it will be individual for every of them

            while (DateTime.Now < startTime + day && zonesToVisit.Count > 0)
            {
                //Console.WriteLine(startTime + day);
                foreach (var worker in _zoo.Workers)
                {
                    if (zonesToVisit.Count > 0)
                    {
                        ZoneTypes zone = zonesToVisit[_random.Next(0, zonesToVisit.Count)];
                        worker.Zone = zone;
                        _currentWorkerZones[worker] = zone;
                        zonesToVisit.Remove(zone);

                        Console.WriteLine($"Worker {worker.GetPosition()} arrived at zone {zone} at {DateTime.Now}");
                        AssignRandomAnimaltoWorker(worker);
                        worker.TreatAnimal();
                        double randomTime = _random.NextDouble() * day.TotalMilliseconds / Enum.GetValues(typeof(ZoneTypes)).Length;
                        TimeSpan timeToNextZone = TimeSpan.FromMilliseconds(randomTime);
                        Thread.Sleep(timeToNextZone);
                    }
                }
            }
        }

        public event EventHandler<TourEventArgs> TourStarted;
        public event EventHandler<TourEventArgs> TourFinished;

        public Tours(Zoo.Zoo zoo)
        {
            _zoo = zoo;
            _activeTours = new List<Tour>();
            _waitingVisitors = new List<Visitors>();
            _random = new Random();
            _currentWorkerZones = new Dictionary<ZooWorker, ZoneTypes>();

            //check it
            foreach (var worker in _zoo.Workers)
            {
                worker.WorkStarted += Worker_WorkStarted;
                worker.WorkFinished += Worker_WorkFinished;
            }
        }

        public void Run()
        {
            
            var day = TimeSpan.FromMinutes(_dayLength);
            var endTime = DateTime.Now + day;

            ScheduleWorkers(day, endTime);

            while (DateTime.Now < endTime)
            {
                
                Thread.Sleep(TimeSpan.FromSeconds(10));

                if (_waitingVisitors.Count >= _maxVisitorsNum)
                {
                    ZoneTypes zone = (ZoneTypes)_random.Next(0, Enum.GetValues(typeof(ZoneTypes)).Length);
                    StartTour(zone);
                }

                /*foreach (var worker in _zoo.Workers)
                {
                    AssignWorkerToRandomZone(worker);
                    AssignRandomAnimaltoWorker(worker);
                }*/
            }
        }

        private void AssignRandomAnimaltoWorker(ZooWorker worker)
        {
            var animalsInZone = _zoo.Animals.Where(a => a.Zone == worker.Zone).ToList();
            Console.WriteLine($"Num in zone: {animalsInZone.Count}");
            if (animalsInZone.Count > 0)
            {
                worker.CurrentAnimal = animalsInZone[_random.Next(0, animalsInZone.Count)];
            }
        }
        private void AssignWorkerToRandomZone(ZooWorker worker)
        {
            if (!_currentWorkerZones.ContainsKey(worker))
            {
                _currentWorkerZones[worker] = (ZoneTypes)_random.Next(0, Enum.GetValues(typeof(ZoneTypes)).Length);
            }
            else
            {
                _currentWorkerZones[worker] =
                    (ZoneTypes)(((int)_currentWorkerZones[worker] + 1) % Enum.GetValues(typeof(ZoneTypes)).Length);
            }
        }

        private bool CanStartTour(ZoneTypes zone)
        {
            for (int i = 0; i < _activeTours.Count; i++)
            {
                var currentZone = _activeTours[i].Zone;
                if (TourConstraints[(int)zone, (int)currentZone] == 0)
                {
                    return false;
                }

                foreach (var worker in _zoo.Workers)
                {
                    if (_currentWorkerZones.TryGetValue(worker, out var workerZone) && workerZone == zone)
                    {
                        return false;
                    }
                }
            }

            return _activeTours.Count(x => x.Zone == zone) < 2;
        }

        private void StartTour(ZoneTypes zone)
        {
            if (!CanStartTour(zone))
            {
                return;
            }

            var tour = new Tour
            {
                Zone = zone,
                Visitors = _waitingVisitors.Take(5).ToList(),
                StartTime = DateTime.Now
            };

            _waitingVisitors.RemoveRange(0, 5);
            _activeTours.Add(tour);

            TourStarted?.Invoke(this, new TourEventArgs(tour));

            ThreadPool.QueueUserWorkItem(_ =>
            {
                /*while (_zoo.Workers.Any(w => _currentWorkerZones.ContainsKey(w) && _currentWorkerZones[w] == zone && w.Working))
                {
                    Thread.Sleep(100);
                }
                */
                Thread.Sleep(TimeSpan.FromSeconds(10));
                tour.EndTime = DateTime.Now;
                _activeTours.Remove(tour);

                TourFinished?.Invoke(this, new TourEventArgs(tour));
            });
        }
        private void Worker_WorkStarted(object sender, WorkerEventArgs e)
        {
            Console.WriteLine($"Worker {e.Worker.GetPosition()} started working at {e.Timestamp} in zone {_currentWorkerZones[e.Worker]}");
        }

        private void Worker_WorkFinished(object sender, WorkerEventArgs e)
        {
            Console.WriteLine($"Worker {e.Worker.GetPosition()} finished working at {e.Timestamp} in zone {_currentWorkerZones[e.Worker]}");
        }
    }

    public class TourEventArgs : EventArgs
    {
        public Tour Tour { get; set; }

        public TourEventArgs(Tour tour)
        {
            Tour = tour;
        }
    }
}

            