using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Whale : Animal
    {
        public Whale(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Sea;
            _sound = "Whale Sound";
        }
    }
}
