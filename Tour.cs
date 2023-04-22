using CSharp_Zoo.ZooWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*private ZoneTypes GetNextZoneForWorker(ZooWorker worker)
        {
            if (!_currentWorkerZones.ContainsKey(worker))
            {
                var availableZones = Enum.GetValues(typeof(ZoneTypes)).Cast<ZoneTypes>().ToList();
                availableZones.RemoveAll(zone => _currentWorkerZones.Values.Contains(zone));
                _currentWorkerZones[worker] = availableZones[_random.Next(0, availableZones.Count)];
            }
            else
            {
                var currentZone = _currentWorkerZones[worker];
                var nextZone = (ZoneTypes)(((int)currentZone + 1) % Enum.GetValues(typeof(ZoneTypes)).Length);
                _currentWorkerZones[worker] = nextZone;
            }
            return _currentWorkerZones[worker];
        }*/

        private void ScheduleWorkers()
        {
            TimeSpan day = TimeSpan.FromMinutes(2);
            DateTime startTime = DateTime.Now;

            while (DateTime.Now < startTime + day)
            {
                foreach (var worker in _zoo.Workers)
                {
                    List<ZoneTypes> zonesToVisit = Enum.GetValues(typeof(ZoneTypes)).Cast<ZoneTypes>().ToList();

                    while (zonesToVisit.Count > 0)
                    {
                        ZoneTypes zone = zonesToVisit[_random.Next(0, zonesToVisit.Count)];
                        _currentWorkerZones[worker] = zone;
                        zonesToVisit.Remove(zone);

                        Console.WriteLine($"Worker {worker.GetPosition()} arrived at zone {zone} at {DateTime.Now}");
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

            foreach (var worker in _zoo.Workers)
            {
                worker.WorkStarted += Worker_WorkStarted;
                worker.WorkFinished += Worker_WorkFinished;
            }
        }

        public void Run()
        {
            
            var day = TimeSpan.FromMinutes(2);
            var endTime = DateTime.Now + day;

            ScheduleWorkers();

            while (DateTime.Now < endTime)
            {
                
                Thread.Sleep(TimeSpan.FromSeconds(10));

                if (_waitingVisitors.Count >= 5)
                {
                    ZoneTypes zone = (ZoneTypes)_random.Next(0, Enum.GetValues(typeof(ZoneTypes)).Length);
                    StartTour(zone);
                }

                foreach (var worker in _zoo.Workers)
                {
                    AssignWorkerToRandomZone(worker);
                }
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

            