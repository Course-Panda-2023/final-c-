using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Kangaroo : Animal
    {
        public Kangaroo(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Land;
            _sound = "Kangaroo Sound";
        }
    }
}
