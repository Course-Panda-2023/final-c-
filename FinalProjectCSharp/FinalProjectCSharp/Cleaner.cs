using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Cleaner : ZooWorker
    {
        public Cleaner(String name, Area workArea) : base(name, workArea)
        {
            _workTime = getWorkTimeOfWorker(typeof(Cleaner));
        }
    }
}
