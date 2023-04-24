using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Whale : SeaAnimals
    {
        public Whale(string name) : base(name)
        {
            Sound = "Whale sound";
        }
    }
}
