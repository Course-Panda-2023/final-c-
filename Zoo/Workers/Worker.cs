using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Workers
{
    public abstract class Worker : Person
    {
        Dictionary<int, Area> WorkAreaTime;
        public Area WorkArea;
        public int WorkTime; //seconds

        protected Worker(string name) : base(name)
        {
        }

        //In order to keep OOP, workerer types that delay a tour will not allow tourists,
        //to continue their tour while working (prevents asking in zoo class which worker type is working)
        public abstract void DoWork();

        private bool CanHaveWorkInRange(int newWorkTime)
        {
            if (this.WorkArea != null)
            {
                bool notInRangeOfExistingWork;
                foreach (int keyTime in this.WorkAreaTime.Keys)
                {
                    notInRangeOfExistingWork = keyTime - this.WorkTime > newWorkTime 
                        || keyTime + this.WorkTime < newWorkTime;

                    if (!notInRangeOfExistingWork)
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }
        public void InitWorkingTimes()
        {
            Random rnd = new Random();
            const int SECONDS_IN_DAY = 120;

            int maxWorkHour = SECONDS_IN_DAY - this.WorkTime;
            WorkAreaTime = new Dictionary<int, Area>();

            //foreach area in Area enum
            foreach (Area area in Enum.GetValues(typeof(Area))) { 
                int timeToWork = rnd.Next(maxWorkHour);

                while (!CanHaveWorkInRange(timeToWork))
                {
                    timeToWork = rnd.Next(maxWorkHour);
                }

                WorkAreaTime.Add(timeToWork, area);
            }
        }

        public bool IsWorkingAtTime(int time)
        {
            try
            {
                return this.WorkAreaTime[time] != null;
            } 
            //when no one work at certain time
            catch(System.Collections.Generic.KeyNotFoundException excetion)
            {
                return false;
            }
        }


    }
}
