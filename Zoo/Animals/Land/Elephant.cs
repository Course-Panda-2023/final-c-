using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Elephant : LandAnimals
    {
        public Elephant(string name) : base(name)
        {
            Sound = "Elephant sound";
        }
    }
}