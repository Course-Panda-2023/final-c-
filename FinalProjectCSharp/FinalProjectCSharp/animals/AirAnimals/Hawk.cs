using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp.animals.AirAnimals
{
    public class Hawk : Animal
    {
        public Hawk(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Air;
            _sound = "Hawk Sound";
        }
    }
}
