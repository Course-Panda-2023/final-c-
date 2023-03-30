using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class Birds : Animal
    {
        public Birds(string name) : base(name)
        {
            _zoneType = ZoneType.birds;
        }
    }
}
