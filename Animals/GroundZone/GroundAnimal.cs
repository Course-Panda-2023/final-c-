using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.AerialZone
{
    public class GroundAnimal : Animal
    {

        private const ZoneTypes _zone = ZoneTypes.Ground;
        public GroundAnimal(string name) : base(name) { }

        //public override void MakeSound() => Console.WriteLine(_sound);
        public override ZoneTypes GetZone() => _zone;

        public override void MakeSound()
        {
            return;
        }
    }
}