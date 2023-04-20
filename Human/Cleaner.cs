using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    delegate void statedOrStopedWorkingCleaner(Cleaner animalWorker, int time);

    internal class Cleaner : Worker
    {
        protected event statedOrStopedWorkingCleaner _start;
        protected event statedOrStopedWorkingCleaner _stop;
        protected bool isWorking;

        public Cleaner(string name) : base(name,2)
        {
            _start += new statedOrStopedWorkingCleaner(Manager.Instance.ReportStartCleaner);
            _stop += new statedOrStopedWorkingCleaner(Manager.Instance.ReportFinishCleaner);
            isWorking = false;

        }


        public void startTask(int time)
        {
            Thread task = new Thread(() => Task(_zonesTimeOfWork[time],time));
            task.Start();
        }
        public void Task(ZoneType zone,int time)
        {
            _zoneOfWork = zone;
            _start.Invoke(this, time);
            Thread.Sleep(_timeWork * ZooClass._sec);
            _stop.Invoke(this, time+_timeWork);
            _zoneOfWork = ZoneType.None;
        }


    }
}
