using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    internal class Elephant : Animal
    {
        public Elephant(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Land;
            _sound = "Trumpet";
        }
    }
}
