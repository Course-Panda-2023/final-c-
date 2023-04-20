using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Doctor : AnimalWorker
    {

        public Doctor(Animal animal, string name) : base(animal , name,5)
        {
        }

    }
}
