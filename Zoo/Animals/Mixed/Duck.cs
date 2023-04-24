using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Duck : MixedAnimal
    {
        public Duck(string name) : base(name)
        {
            Sound = "Duck sound";
        }
    }
}
