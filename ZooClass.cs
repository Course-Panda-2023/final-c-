using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Zoo
{
    internal class ZooClass
    {
        private List<Visitor> _visitors; 
        private List<Cleaner> _cleaners;
        private List<Doctor> _doctors;
        private List<Feeder> _feeders;
        private Dictionary<ZoneType,List<Animal>> _zoneWithinAnimals = new();
        public static int _day = 120;
        public static int _tourTime = 10;
        public static int _sec = 100;
        public static List<ZoneType> _zones = new List<ZoneType>() { ZoneType.birds, ZoneType.seaAnimals, ZoneType.landAnimals, ZoneType.mixedAnimals };
        private System.Timers.Timer _timer;
        private int _currTime;
        private Dictionary<Cleaner, Dictionary<int, ZoneType>> _taskHourseCleaners;
        private Dictionary<AnimalWorker, Dictionary<int, ZoneType>> _taskHourseAnimalWorker;
        private List<Tour> _tours;
        private Tour _waitingToStart;
        //private List<Tour> _tourTimes;



        public ZooClass (List<Visitor> visitors,List<Animal> animals,List<Cleaner> cleaners,List<Doctor> doctors,List<Feeder> feeders)
        {
            Validation(GetDict(animals), visitors, cleaners, doctors, feeders);

            _zoneWithinAnimals = GetDict(animals);
            _visitors = visitors; 
            _cleaners = cleaners;
            _doctors = doctors;
            _feeders = feeders;
            
            _taskHourseAnimalWorker = new Dictionary<AnimalWorker, Dictionary<int, ZoneType>>();
            _taskHourseCleaners =new Dictionary<Cleaner, Dictionary<int, ZoneType>>();

            //_tourTimes

            ////
            ///
            _currTime = 0;
            cleaners.ForEach(cleaner => { _taskHourseCleaners.Add(cleaner, cleaner.ZonesTimeOfWork); });
            feeders.ForEach(feeder => { _taskHourseAnimalWorker.Add(feeder, feeder.ZonesTimeOfWork); });
            doctors.ForEach(doctor => {  _taskHourseAnimalWorker.Add(doctor, doctor.ZonesTimeOfWork); });   

            _tours = new List<Tour>();
            //_timer = new System.Timers.Timer();
            //_timer.Elapsed += TimeElapsed;
            //_timer.Interval = _sec;
            //_timer.Start();
            TimeElapsed();


        }


        public Dictionary<ZoneType,List<Animal>> GetDict(List<Animal> animals)
        {
            return animals.GroupBy(animal => animal.zoneType).ToDictionary(animal => animal.Key, animal => animal.ToList());
        }
        public void Validation(Dictionary<ZoneType, List<Animal>> checkValidAnimals , List<Visitor> visitors, List<Cleaner> cleaners, List<Doctor> doctors, List<Feeder> feeders)
        {
            foreach ( ZoneType zoneType in checkValidAnimals.Keys)
            {
                List<Type> l= new List<Type>();
                checkValidAnimals[zoneType].ForEach(x => l.Add(x.GetType()));
                if (l.Distinct().Count() != l.Count())
                    throw new NotValidZooParameters($"can't have more than one animal of each type ({zoneType})");
                if (checkValidAnimals[zoneType].Count < 3)
                    throw new NotValidZooParameters($"need 3 or more animals in {zoneType}");
            }
            if(visitors.Count == 0)
                throw new NotValidZooParameters($"need more than 0 visitors");
                                                  
                                                  
            if (cleaners.Count == 0)               
                throw new NotValidZooParameters($"need more than 0 cleaners");
                                                  
                                                  
            if (doctors.Count == 0)                
                throw new NotValidZooParameters($"need more than 0 doctors");
                                                  
                                                  
            if (feeders.Count == 0)                
                throw new NotValidZooParameters($"need more than 0 feeders");

   
        }

        //public bool AddTaskToDoctorOrFeeder(Animal animal,AnimalWorker DocOrFeed)
        //{
        //    if (DocOrFeed.IsTraetingAnAnimal())
        //        return false;
        //    if(animal.beingTrated)
        //        return false;

        //    animal.beingTrated = true;
        //    DocOrFeed.addTask(animal);
        //    return true;

        //}

        //public void ScheduleWorker()
        //{
            
        //    foreach(Cleaner c in _cleaners)
        //    {
        //        c.ScheduleWorkForDay(_day, new List<ZoneType>() { ZoneType.birds, ZoneType.seaAnimals, ZoneType.landAnimals, ZoneType.mixedAnimals });
        //    }
        //    foreach(Doctor d in _doctors)
        //    {
        //        d.ScheduleWorkForDay(_day, new List<ZoneType>() { ZoneType.birds, ZoneType.seaAnimals, ZoneType.landAnimals, ZoneType.mixedAnimals });
        //    }
        //    foreach(Feeder f in _feeders) 
        //    {
        //        f.ScheduleWorkForDay(_day, new List<ZoneType>() { ZoneType.birds, ZoneType.seaAnimals, ZoneType.landAnimals, ZoneType.mixedAnimals });
        //    }
        //}

        public void TimeElapsed(/*object sender, ElapsedEventArgs e*/) 
        {
            while(_currTime <= _day)
            {
                Manager.Instance.WriteToFile($"--{_currTime}--");

                //
                checkResumeTours();
                //

                CheckTours();

                StartWorkersTasks();




                Thread.Sleep(_sec);
                _currTime++;
            }
            Manager.Instance.WriteToFile("Day ended");
            return;

        }
        //public void ForceTourToWait()
        //{
        //    foreach (Tour t in _tours)
        //    {
        //        Thread thread = new Thread(() => {
        //            t.WaitForSignal();
        //        });

        //    }

        //}
        public void StartWorkersTasks()
        {
            foreach (Cleaner cleaner in _taskHourseCleaners.Keys)
            {
                if (_taskHourseCleaners[cleaner].ContainsKey(_currTime))
                {
                    StopTourInZones(_taskHourseCleaners[cleaner][_currTime]);
                    cleaner.startTask(_currTime);
                }
            }

            foreach (AnimalWorker animalWorker in _taskHourseAnimalWorker.Keys)
            {
                if (_taskHourseAnimalWorker[animalWorker].ContainsKey(_currTime))
                {
                    if (animalWorker.GetType().Equals(typeof(Doctor)))
                        StopTourInZones(_taskHourseAnimalWorker[animalWorker][_currTime]);
                    animalWorker.StartTask(_currTime, GetAvailableAnimalFromZone(_taskHourseAnimalWorker[animalWorker][_currTime]));
                }
            }
        }
      
        //////////
        public void StopTourInZones(ZoneType zone)
        {
            foreach(Tour tour in _tours) 
            {
                if (tour.zoneType == zone)
                {
                    tour.StopTour();
                }
            }
        }

        //public void resumeTour(ZoneType zone)
        //{
        //    foreach (Tour tour in _tours)
        //    {
        //        if (tour.zoneType == zone)
        //        {
                    
        //        }
        //    }
        //}
        public bool CanTourInZone(ZoneType zone)
        {
            foreach(Cleaner c in _cleaners)
            {
                if (c.Zone == zone)
                    return false;
            }
            foreach (Doctor d in _doctors)
            {
                if(d.Zone== zone) 
                    return false; 
            }
            return true;
        }
        public void checkResumeTours()
        {
            foreach(Tour tour in _tours)
            {
                if (tour.inPause)
                {
                    if (CanTourInZone(tour.zoneType))
                    {
                        tour.ResumeTour();
                    }
                }
            }
        }

        //////

        public Animal GetAvailableAnimalFromZone(ZoneType zone)
        {
            foreach(Animal animal in _zoneWithinAnimals[zone])
            {
                if (!animal.beingTrated) 
                {
                    return animal;
                }
            }

            return null;
        }

        public void CheckTours()
        {
            List<Tour> currTours = new List<Tour>(_tours);
            foreach(Tour t in currTours) 
            {
                if(t.isFinished)
                    _tours.Remove(t);
            }
            if( _currTime + _tourTime <= _day)
            {
                if(_waitingToStart == null)
                    _waitingToStart = new Tour(GetAvailableVisitors());
                if (CanStartTour(_waitingToStart))
                {
                    _tours.Add(_waitingToStart);
                    _waitingToStart.Start(_currTime);
                    _waitingToStart = null;
                }
            }

            //ForceTourToWait();


        }


        public bool CanTourInSameTime(Tour running, Tour checking)
        {
            List<ZoneType> zonsToCheck = new List<ZoneType>() {running.zoneType,checking.zoneType};
            //_tours.ForEach(tour => { zonsToCheck.Add(tour.zoneType); });
            if (zonsToCheck.Contains(ZoneType.landAnimals))
            {
                if (zonsToCheck.Contains(ZoneType.seaAnimals) || zonsToCheck.Contains(ZoneType.birds))
                    return false;
                else 
                    return true;
            }
            else if (zonsToCheck.Contains(ZoneType.birds))
            {
                if (zonsToCheck.Contains(ZoneType.mixedAnimals))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        //public void CanStartTour()
        //{
        //    Tour running;
        //    Tour waiting;
        //    if (_tours.Count == 0 )
        //        return;
        //    if(_tours.Count < 2)
        //    {
        //        _tours.Last().Start(_currTime);
        //        return;
        //    }
        //    if (_tours[0].inProcess && _tours[1].inProcess)
        //        return;

        //    if (!_tours[0].inProcess && !_tours[1].inProcess)
        //    {
        //        if (CanTourInSameTime())
        //        {
        //            _tours[0].Start(_currTime);
        //            _tours[1].Start(_currTime); 
        //        }
        //        else
        //            _tours[0].Start(_currTime);
        //    }
        //    else
        //    {
        //        if (_tours[1].inProcess)
        //        {
        //            running = _tours[1];
        //            waiting= _tours[0]; 
        //        }
        //        else
        //        {
        //            running = _tours[0];
        //            waiting = _tours[1];

        //        }
        //        if (CanTourInSameTime())
        //            waiting.Start(_currTime);
        //    }
        //}

        public bool CanStartTour(Tour checking)
        {
            if (FindHowManyToursInSameZone(checking.zoneType) >= 2)
                return false;
            foreach(Tour tour in _tours) 
            {
                if(!CanTourInSameTime(tour,checking))
                    return false;

            }
            if (!CanTourInZone(checking.zoneType))
                return false;
            return true;    
        }

        public int FindHowManyToursInSameZone(ZoneType zone)
        {
            int ret = 0;
            foreach(Tour tour in _tours)
            {
                if (tour.zoneType == zone)
                    ret++;
            }
            return ret;
        }

        public List<Visitor> GetAvailableVisitors()
        {
            List<Visitor> ret = new List<Visitor>();
            foreach(Visitor visitor in _visitors)
            {
                if (!visitor.inATour)
                {
                    visitor.inATour = true;
                    ret.Add(visitor);
                }
                if (ret.Count == 5)
                    break;

            }
            return ret;
        }


    }
 
}
