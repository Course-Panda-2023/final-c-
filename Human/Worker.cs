using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class Worker : Human
    {
        protected ZoneType _zoneOfWork;
        protected int _timeWork;
        protected Dictionary<int, ZoneType> _zonesTimeOfWork;

        public ZoneType Zone { get { return _zoneOfWork; } }

        public Dictionary<int, ZoneType> ZonesTimeOfWork { get { return _zonesTimeOfWork; } }   

        protected Worker(string name, int time) : base(name)
        { 
            _zoneOfWork = ZoneType.None;
            _zonesTimeOfWork = new Dictionary<int, ZoneType>();
            _timeWork = time;
            ScheduleWorkForDay(ZooClass._day,new List<ZoneType>(ZooClass._zones));

        }

        public void ScheduleWorkForDay(int day ,List<ZoneType> zones)
        {
            Random random = new Random();

            int len = zones.Count;
            int sections = day / len;
            int optionalStartingTime = sections - _timeWork;
            for (int i = 0; i < len; i++)
            {

                ZoneType curr = zones.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                _zonesTimeOfWork.Add( random.Next(sections * i, sections * i + optionalStartingTime) , curr);
                zones.Remove(curr);
            }
        }

        
   
         
        //public abstract void StartTask(int time)
        //{
        //    Thread task = new Thread(() => Task(_zonesTimeOfWork[time]));
        //    task.Start();
        //}

        //public abstract void Task(ZoneType zone);
    }
}
