using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Crocodile : Animal
    {
        public Crocodile(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Mixed;
            _sound = "Crocodile Sound";
        }
    }
}
