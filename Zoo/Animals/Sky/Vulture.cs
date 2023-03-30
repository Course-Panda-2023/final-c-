using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Vulture : SkyAnimals
    {
        public Vulture(string name) : base(name)
        {
            Sound = "Vulture cawwww";
        }
    }
}
