using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Kangaroo : LandAnimals
    {
        public Kangaroo(string name) : base(name)
        {
            Sound = "Kangaroo sound";
        }
    }
}
