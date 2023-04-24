using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.AerialZone
{
    public class AerialAnimal : Animal
    {
        
        //private const ZoneTypes _zone = ZoneTypes.Aerial;
        public AerialAnimal(string name) : base(name, ZoneTypes.Aerial) {}
        

        
        public override ZoneTypes GetZone() => _zone;

        public override void MakeSound()
        {
            return;
        }
    }
}
