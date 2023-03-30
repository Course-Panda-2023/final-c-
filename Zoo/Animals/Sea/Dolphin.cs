using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Dolphin : SeaAnimals
    {
        public Dolphin(string name) : base(name)
        {
            Sound = "eEeEeEeEeEeEeEeEeEeE";
        }
    }
}
