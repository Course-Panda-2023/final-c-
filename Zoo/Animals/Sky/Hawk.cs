using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Hawk : SkyAnimals
    {
        public Hawk(string name) : base(name)
        {
            Sound = "Hawk sound";
        }
    }
}
