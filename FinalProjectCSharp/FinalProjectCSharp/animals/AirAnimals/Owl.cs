using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Owl : Animal
    {
        public Owl(string animalName) : base()
        {
            _animalName = animalName;
            _area = Area.Air;
            _sound = "Owl Sound";
        }
    }
}
