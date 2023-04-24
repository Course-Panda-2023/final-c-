using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Frog : MixedAnimal
    {
        public Frog(string name) : base(name)
        {
            Sound = "Frog sound";
        }
    }
}
