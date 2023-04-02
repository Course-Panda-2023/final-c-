using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Eagle : Animal
    {
        public Eagle(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Air;
            _sound = "Eagle Sound";
        }
    }
}
