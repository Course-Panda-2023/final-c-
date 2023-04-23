using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Shark : Animal
    {
        public Shark(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Sea;
            _sound = "Shark Sound";
        }
    }
}
