using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Zebra : LandAnimals
    {
        public Zebra(string name) : base(name)
        {
            Sound = "Zebra sound";
        }
    }
}
