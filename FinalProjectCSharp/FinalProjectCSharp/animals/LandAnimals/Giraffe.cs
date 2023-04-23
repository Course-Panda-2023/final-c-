using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    internal class Giraffe : Animal
    {
        public Giraffe(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Land;
            _sound = "Giraffe Sound";
        }
    }
}
