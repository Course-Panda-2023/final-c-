using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    delegate void statedOrStopedWorkingAnimal(AnimalWorker animalWorker, int time);
    internal abstract class AnimalWorker : Worker
    {
        protected Animal _animal;
        protected event statedOrStopedWorkingAnimal _start;
        protected event statedOrStopedWorkingAnimal _stop;




        public Animal Animal { get { return _animal; } set { _animal = value; } }

        public AnimalWorker(Animal animal, string name,int timeWork) : base(name,timeWork)
        {
            _start += new statedOrStopedWorkingAnimal(Manager.Instance.ReportStartAnimals);
            _stop += new statedOrStopedWorkingAnimal(Manager.Instance.ReportFinishAnimals);


            _animal = animal;
        }
        //public bool IsTraetingAnAnimal()
        //{
        //    return _animal != null;
        //}

        //public void addTask(Animal animal)
        //{
        //    _animal = animal;
        //}
        //public void removeTask() 
        //{
        //    _animal = null;
        //}

        public void StartTask(int time,Animal animal)
        {
            Thread task = new Thread(() => Task(_zonesTimeOfWork[time],animal,time));
            task.Start();
        }

        

        public void Task(ZoneType zone,Animal animal,int time)
        {
            if (animal == null)
            {
                Manager.Instance.WriteToFile($"[{time}] {_name} I dont have work in {zone}");
                return;

            }
            _zoneOfWork = zone;
            _animal = animal;
            animal.beingTrated = true;
            _start.Invoke(this, time);
            Thread.Sleep(_timeWork * ZooClass._sec);
            _stop.Invoke(this, time + _timeWork);
            _animal = null;
            animal.beingTrated = false;
            _zoneOfWork = ZoneType.None;
        }
    }
}
