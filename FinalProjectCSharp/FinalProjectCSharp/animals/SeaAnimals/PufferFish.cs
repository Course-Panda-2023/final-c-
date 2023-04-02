using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class PufferFish : Animal
    {
        public PufferFish(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Sea;
            _sound = "Puffer Fish Sound";
        }
    }
}
