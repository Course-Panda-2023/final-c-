using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Feeder : AnimalWorker
    {
        public Feeder(Animal animal, string name) : base(animal ,name , 10)
        {
        }


    }
}
