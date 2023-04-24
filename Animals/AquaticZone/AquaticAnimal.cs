using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.AerialZone
{
    public class AquaticAnimal : Animal
    {

        //private const ZoneTypes _zone = ZoneTypes.Aquatic;
        public AquaticAnimal(string name) : base(name, ZoneTypes.Aquatic) { }

        //public override void MakeSound() => Console.WriteLine(_sound);
        public override ZoneTypes GetZone() => _zone;

        public override void MakeSound()
        {
            return;
        }

    }
}