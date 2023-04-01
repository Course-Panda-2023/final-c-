using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class GoldFish : SeaAnimals
    {
        public GoldFish(string name) : base(name)
        {
            Sound = "Goldfish sound";
        }
    }
}
