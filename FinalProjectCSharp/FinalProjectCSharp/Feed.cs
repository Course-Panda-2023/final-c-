using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Feed : WorkWithAnimal
    {
        public Feed(String name, Area workArea) : base(name, workArea)
        {
            _workTime = getWorkTimeOfWorker(typeof(Feed));
            _action = "feeding";
        }
    }
}
