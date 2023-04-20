using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class MixedAnimals : Animal
    {
        public MixedAnimals(string name) : base(name)
        {
            _zoneType = ZoneType.mixedAnimals;
        }
    }
}
