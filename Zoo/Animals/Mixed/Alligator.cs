using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Alligator : MixedAnimal
    {
        public Alligator(string name) : base(name)
        {
            Sound = "Grrrrrrr";
        }
    }
}
