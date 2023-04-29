using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.GroundZone
{
    public class GroundAnimal : Animal
    {

        
        public GroundAnimal(string name) : base(name, ZoneTypes.Ground) {}


        public override void MakeSound()
        {
            return;
        }
    }
}