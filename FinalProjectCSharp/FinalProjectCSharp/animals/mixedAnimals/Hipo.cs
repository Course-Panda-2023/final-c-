using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Hipo : Animal
    {
        public Hipo(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Mixed;
            _sound = "Hipo Sound";
        }
    }
}
