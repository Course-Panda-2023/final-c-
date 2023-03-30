using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class SeaAnimals : Animal
    {
        public SeaAnimals(string name) : base(name)
        {
            areas = Areas.Sea;
        }
    }
}
