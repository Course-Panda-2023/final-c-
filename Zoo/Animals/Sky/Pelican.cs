using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Pelican : SkyAnimals
    {
        public Pelican(string name) : base(name)
        {
            Sound = "Pelican sound";
        }
    }
}
