using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class MixedAnimal : Animal
    {
        public MixedAnimal(string name) : base(name)
        {
            areas = Areas.Mixed;
        }
    }
}
