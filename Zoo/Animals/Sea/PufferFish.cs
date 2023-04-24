using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class PufferFish : SeaAnimals
    {
        public PufferFish(string name) : base(name)
        {
            Sound = "PufferFish sound";
        }
    }
}
