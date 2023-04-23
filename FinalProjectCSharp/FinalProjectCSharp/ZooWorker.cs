using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class ZooWorker
    {
        protected string _name;
        public string Name { get { return _name; } }
        protected Area _workArea;
        public Area Area { get { return _workArea; } }
        protected int _workTime;
        public int WorkTime { get { return _workTime; } }

        public ZooWorker(String name, Area workArea)
        {
            _workArea = workArea;
            _name = name;
        }

        protected static int getWorkTimeOfWorker(Type type)
        {
            if (type == typeof(Cleaner))
                return 2;
            else if (type == typeof(Feed))
                return 10;
            else if (type == typeof(Doctor))
                return 5;
            return 0;
        }

    }
}
