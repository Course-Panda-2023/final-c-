using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Turtle : Animal
    {
        public Turtle(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Mixed;
            _sound = "Turtle Sound";
        }
    }
}
