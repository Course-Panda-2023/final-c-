using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Vulture : Animal
    {
        public Vulture(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Air;
            _sound = "Vulture Sound";
        }
    }
}
