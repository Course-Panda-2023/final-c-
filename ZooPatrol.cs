﻿using CSharp_Zoo.Animals;
using CSharp_Zoo.ZooWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Zoo;
//using CSharp_Zoo.Zoo;
namespace CSharp_Zoo
{
    /*public class StaffPatrol_old
    {

        //private readonly Zoo.Zoo _zoo;
        private readonly int[,] _constraintsTable = new int[,] { { 1, 0, 0, 1 }, { 0, 1, 1, 0 }, { 0, 1, 1, 1 }, { 1, 0, 1, 1 } };
        private readonly int[] _numPatrols = new int[] { 0, 0, 0, 0 };
        private readonly int[] _numWorkersOnPatrol = new int[] { 0, 0, 0, 0 };
        private readonly Dictionary<int, List<ZooWorker>> _workersByZone;// = new Dictionary<int, List<ZooWorker>>();
        private readonly Dictionary<int, List<ZooWorker>> _workersOnPatrolByZone;// = new Dictionary<int, List<ZooWorker>>();
        private readonly List<ZooWorker> _workersStandBy = new List<ZooWorker>();
        private readonly Random _random = new Random();
        private bool _isPatrolling = false;

        
        public StaffPatrol()
        {
            //_zoo = zoo;
            for (int i = 0; i < 4; i++)
            {
                _workersByZone[i] = new List<ZooWorker>();
                _workersOnPatrolByZone[i] = new List<ZooWorker>();
                //_zones = Enum.GetValues(typeof(ZoneTypes)).Cast<ZoneTypes>().Where(z => z != ZoneTypes.None).ToList();
            }
        }

        public void Patrol()
        {
            while (true)
            {
                // wait until there are five workers available
                while (_workersStandBy.Count < 5)
                {
                    Thread.Sleep(1000);
                }

                // select five workers to perform patrol
                List<ZooWorker> workers = new List<ZooWorker>();
                for (int i = 0; i < 5; i++)
                {
                    int index = _random.Next(_workersStandBy.Count);
                    workers.Add(_workersStandBy[index]);
                    _workersStandBy.RemoveAt(index);
                }

                // select the zone to perform patrol
                int zone = SelectZone();

                // wait until the zone is available for patrol
                while (!IsAvailableForPatrol(zone))
                {
                    Thread.Sleep(1000);
                }

                // perform patrol
                _isPatrolling = true;
                _numPatrols[zone]++;
                _numWorkersOnPatrol[zone] += 5;
                _workersOnPatrolByZone[zone].AddRange(workers);
                foreach (ZooWorker worker in workers)
                {
                    _workersByZone[zone].Remove(worker);
                    worker.StartPatrol(zone);
                }
                Thread.Sleep(10000);
                foreach (ZooWorker worker in workers)
                {
                    worker.FinishPatrol(zone);
                }
                _workersOnPatrolByZone[zone].Clear();
                _numWorkersOnPatrol[zone] = 0;
                _isPatrolling = false;

                // add workers to stand by
                foreach (ZooWorker worker in workers)
                {
                    _workersByZone[zone].Add(worker);
                    _workersStandBy.Add(worker);
                }
            }
        }

        public void AddWorker(ZooWorker worker, int zone)
        {
            _workersByZone[zone].Add(worker);
            _workersStandBy.Add(worker);
        }

        public void RemoveWorker(ZooWorker worker, int zone)
        {
            if (!_isPatrolling || !_workersOnPatrolByZone[zone].Contains(worker))
            {
                _workersByZone[zone].Remove(worker);
                _workersStandBy.Remove(worker);
            }
        }

        private int SelectZone()
        {
            List<int> availableZones = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (IsAvailableForPatrol(i))
                {
                    availableZones.Add(i);
                }
            }
            int index = _random.Next(availableZones.Count);
            return availableZones[index];
        }

        private bool IsAvailableForPatrol(int zone)
        {
            for (int i = 0; i < 4; i++)
            {
                if (_numWorkersOnPatrol[i] > 0 && _constraintsTable[zone, i] == 0)
                {
                    return false;
                }
            }
            int numWorkers = _workersByZone[zone].Count;
            if (numWorkers < 5 && _numPatrols[zone] == 0)
            {
                return true;
            }
            if (numWorkers >= 5 && _numPatrols[zone] < 3)
            {
                return true;
            }
            return false;
        }
    }*/


    /*public class StaffPatrol_workers_old
    {
        private readonly Zoo.Zoo _zoo;
        private readonly int _dayDuration = 120000; // 2 minutes
        private readonly int _patrolDuration = 10000; // 10 seconds
        private readonly object _patrolLock = new object();
        private readonly Dictionary<ZoneTypes, int> _zonePatrolCount = new Dictionary<ZoneTypes, int>();
        private readonly Random _random = new Random();
        public static readonly int[,] AllowedSimultaneousPatrols = new int[,]
        {
            { 1, 0, 0, 1 },
            { 0, 1, 1, 0 },
            { 0, 1, 1, 1 },
            { 1, 0, 1, 1 }
        };
        public StaffPatrol(Zoo.Zoo zoo)
        {
            //_zoo = zoo;
            foreach (ZoneTypes zone in Enum.GetValues(typeof(ZoneTypes)))
            {
                _zonePatrolCount[zone] = 0;
            }
        }

        public void StartPatrol()
        {
            while (true)
            {
                Patrol();
                Thread.Sleep(_dayDuration);
            }
        }

        private void Worker_WorkStatusChanged(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private void Patrol()
        {
            List<ZooWorker> workers = new List<ZooWorker>(_zoo.Workers);
            List<ZooWorker> selectedWorkers = new List<ZooWorker>();

            while (selectedWorkers.Count < 5)
            {
                int randomWorkerIndex = _random.Next(workers.Count);
                ZooWorker worker = workers[randomWorkerIndex];
                workers.RemoveAt(randomWorkerIndex);
                selectedWorkers.Add(worker);
            }

            List<Thread> patrolThreads = new List<Thread>();

            foreach (var worker in selectedWorkers)
            {
                Thread patrolThread = new Thread(() => PatrolZone(worker));
                patrolThreads.Add(patrolThread);
                patrolThread.Start();
            }

            foreach (var patrolThread in patrolThreads)
            {
                patrolThread.Join();
            }
        }

        private void PatrolZone(ZooWorker worker)
        {
            ZoneTypes zone;
            lock (_patrolLock)
            {
                do
                {
                    zone = GetRandomZone();
                } while (!CanPatrolZone(zone));
                _zonePatrolCount[zone]++;
            }

            worker.WorkStatusChanged += Worker_WorkStatusChanged;
            worker.OnWorkStatusChanged($"Worker {worker.GetPosition()} started patrolling zone {zone}");
            int patrolTime = _patrolDuration + worker.WorkingTime() * 1000;
            Thread.Sleep(patrolTime);
            worker.OnWorkStatusChanged($"Worker {worker.GetPosition()} finished patrolling zone {zone}");
            worker.WorkStatusChanged -= Worker_WorkStatusChanged;

            lock (_patrolLock)
            {
                _zonePatrolCount[zone]--;
            }
        }

        private ZoneTypes GetRandomZone()
        {
            Array zones = Enum.GetValues(typeof(ZoneTypes));
            ZoneTypes randomZone = (ZoneTypes)zones.GetValue(_random.Next(zones.Length));
            return randomZone;
        }

        private bool CanPatrolZone(ZoneTypes zone)
        {
            int currentZoneIndex = (int)zone;
            for (int i = 0; i < Enum.GetValues(typeof(ZoneTypes)).Length; i++)
            {
                if (AllowedSimultaneousPatrols[currentZoneIndex, i] != 0)
                {
                    continue;
                }

                if (_zonePatrolCount[(ZoneTypes)i] > 0)
                {
                    return false;
                }
            }

            return _zonePatrolCount[zone] < 2;
        }

    }*/

}






















    