using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Duck : Animal
    {
        public Duck(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Mixed;
            _sound = "Duck Sound";
        }
    }
}
