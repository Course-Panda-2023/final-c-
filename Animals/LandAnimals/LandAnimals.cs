using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class LandAnimals : Animal
    {
        public LandAnimals(string _name):base(_name)
        {
            _zoneType = ZoneType.landAnimals;
        }
    }
}
