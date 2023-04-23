using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Pelican : Animal
    {
        public Pelican(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Air;
            _sound = "Pelican Sound";
        }
    }
}
