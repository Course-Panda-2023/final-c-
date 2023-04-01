using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Turtle : MixedAnimal
    {
        public Turtle(string name) : base(name)
        {
            Sound = "Turtle sound";
        }
    }
}
