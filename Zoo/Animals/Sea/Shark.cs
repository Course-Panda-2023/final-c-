using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Shark : SeaAnimals
    {
        public Shark(string name) : base(name)
        {
            Sound = "Shark sound";
        }
    }
}
