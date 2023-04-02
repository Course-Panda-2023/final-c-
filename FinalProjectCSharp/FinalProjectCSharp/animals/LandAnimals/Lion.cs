using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Lion : Animal
    {
        public Lion(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Land;
            _sound = "Roar";
        }
    }
}
