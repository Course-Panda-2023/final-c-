using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Hippopotumus : MixedAnimal
    {
        public Hippopotumus(string name) : base(name)
        {
            Sound = "Hippopotumus sound";
        }
    }
}
