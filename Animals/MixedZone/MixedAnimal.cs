using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.MixedZone
{
    public class MixedAnimal : Animal
    {

        
        public MixedAnimal(string name) : base(name, ZoneTypes.Mixed) { }


        public override void MakeSound() {}

    }
}