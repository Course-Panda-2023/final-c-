using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.AerialZone
{
    public class MixedAnimal : Animal
    {

        private const ZoneTypes _zone = ZoneTypes.Mixed;
        public MixedAnimal(string name) : base(name, ZoneTypes.Mixed) { }

        //public override void MakeSound() => Console.WriteLine(_sound);
        public override ZoneTypes GetZone() => _zone;

        public override void MakeSound() {}

    }
}