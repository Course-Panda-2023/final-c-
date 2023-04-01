using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Giraffe : LandAnimals
    {
        public Giraffe(string name) : base(name)
        {
            Sound = "Giraffe sound";
        }
    }
}
